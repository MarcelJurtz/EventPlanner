using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Planner.Config;
using Planner.Models;
using Planner.Models.Enums;
using Planner.Models.Helper;
using Planner.Models.Repository;
using Planner.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Planner.Controllers
{
    [Authorize(Roles = RoleNames.ROLE_MEMBER)]
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IEventParticipationRepository _participationRepository;
        private readonly IEventAssociationRepository _eventAssociationRepository;
        private readonly IUserRepository _userRepository;
        private readonly INotificationConfigurationRepository _notificationConfigurationRepository;
        private readonly UserManager<User> _userManager;
        private readonly EMailSender _eMailSender;

        // Constructor parameters will be injected 
        // because the objects have been registered in startup.cs
        public EventController(IEventRepository eventRepository, ITeamRepository teamRepository, IEventParticipationRepository participationRepository, 
            IEventAssociationRepository eventAssociationRepository, IUserRepository userRepository, INotificationConfigurationRepository configurationRepository, 
            UserManager<User> usermanager, IOptions<AuthMessageSenderOptions> config)
        {
            _eventRepository = eventRepository;
            _teamRepository = teamRepository;
            _participationRepository = participationRepository;
            _eventAssociationRepository = eventAssociationRepository;
            _userRepository = userRepository;
            _notificationConfigurationRepository = configurationRepository;
            _userManager = usermanager;
            _eMailSender = new EMailSender(config);
        }

        // Auflistung aller Events
        public async Task<ViewResult> Index() // Action
        {
            EventListViewModel viewModel = new EventListViewModel();
            //var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.GetUserAsync(this.User);
            viewModel.TeamNames = _teamRepository.GetForUser(user.UserId).Select(t => t.Designation).ToArray();
            viewModel.Events = _eventRepository.GetAllForUser(user.UserId, true);
            return View(viewModel); // View to Show -> Render default view for this method action
            // Default View: Controller will search in View-Subfolder for View with same name as the controller
            // Passing Parameters to View results in a strongly typed view. Alternative: Razor / ViewBag-Property
        }

        // Auflistung von Events, die noch nicht beantwortet werden
        public async Task<ViewResult> Unread()
        {
            EventListViewModel viewModel = new EventListViewModel();
            var user = await _userManager.GetUserAsync(this.User);
            viewModel.TeamNames = _teamRepository.GetForUser(user.UserId).Select(t => t.Designation).ToArray();
            viewModel.Events = _eventRepository.GetUnreadForUser(user.UserId, true);
            return View(viewModel);

        }

        [Authorize(Roles = RoleNames.ROLE_ADMIN)]
        public ViewResult Add()
        {
            EventEditViewModel viewModel = new EventEditViewModel();
            viewModel.CurrentEvent = new Models.Event();
            viewModel.Teams = _teamRepository.GetAll().ToList();
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.ROLE_ADMIN)]
        public IActionResult Add(EventEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            viewModel.CurrentEvent.Created = DateTime.Now;

            _eventRepository.Add(viewModel.CurrentEvent);

            var associations = new List<EventAssociation>();
            var date = DateTime.Now;
            foreach(var team in viewModel.Teams)
            {
                if (team.Selected)
                    associations.Add(new EventAssociation()
                    {
                        Created = date,
                        Modified = date,
                        TeamId = team.Id,
                        EventId = viewModel.CurrentEvent.Id
                    });
            }

            _eventAssociationRepository.AddRange(associations);

            return RedirectToAction("Administrate");
        }

        public async Task<IActionResult> Participate(int? id)
        {
            if(id == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            EventParticipateViewModel viewModel = new EventParticipateViewModel();
            viewModel.CurrentEvent = _eventRepository.Find(x => x.Id == id).FirstOrDefault();

            if (viewModel.CurrentEvent == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            var user = await _userManager.GetUserAsync(this.User);
            var participation = _participationRepository.Find(x => x.EventId == id && x.UserId == user.UserId).FirstOrDefault();

            viewModel.DisplayIsPlayer = viewModel.CurrentEvent.PlayersRequired > 0;
            viewModel.DisplayIsCoach = viewModel.CurrentEvent.CoachesRequired > 0;
            viewModel.DisplayIsUmpire = viewModel.CurrentEvent.UmpiresRequired > 0;
            viewModel.DisplayIsScorer = viewModel.CurrentEvent.ScorersRequired > 0;
            viewModel.DisplayHasSeats = viewModel.CurrentEvent.SeatsRequired > 0;

            if (participation != null)
            {
                if (participation.AnswerYes)
                    viewModel.ParticipationType = ParticipationTypesEnum.yes;
                else if (participation.AnswerNo)
                    viewModel.ParticipationType = ParticipationTypesEnum.no;
                else
                    viewModel.ParticipationType = ParticipationTypesEnum.maybe;

                viewModel.Note = participation.Note;
                viewModel.IsPlayer = participation.IsPlayer;
                viewModel.IsCoach = participation.IsCoach;
                viewModel.IsUmpire = participation.IsUmpire;
                viewModel.IsScorer = participation.IsScorer;
                viewModel.HasSeats = participation.Seats;
            }
            else
            {
                viewModel.ParticipationType = ParticipationTypesEnum.maybe;
            }

            if (viewModel.CurrentEvent != null)
                return View(viewModel);
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Participate(int? id, EventParticipateViewModel viewModel)
        {
            if (id == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            var user = await _userManager.GetUserAsync(this.User);

            _participationRepository.Update((int)id, user.UserId,viewModel);

            // Send participation update to opted-in admins
            var admins = await _userManager.GetUsersInRoleAsync(RoleNames.ROLE_ADMIN);
            foreach(var admin in admins)
            {
                var config = _notificationConfigurationRepository.GetConfigurationForUser(admin.UserId);
                if(config != null && config.UserParticipationUpdated)
                {
                    await _eMailSender.SendUserParticipationEmail(admin.Email);
                }
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = RoleNames.ROLE_ADMIN)]
        public IActionResult Administrate()
        {
            EventListViewModel viewModel = new EventListViewModel();
            viewModel.Events = _eventRepository.GetAll();
            return View(viewModel);
        }

        [Authorize(Roles = RoleNames.ROLE_ADMIN)]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            EventEditViewModel viewModel = new EventEditViewModel();
            viewModel.CurrentEvent = _eventRepository.Find(x => x.Id == id).FirstOrDefault();
            if (viewModel.CurrentEvent == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            viewModel.Teams = _teamRepository.GetAll().ToList();

            var associations = _eventAssociationRepository.Find(x => x.EventId == id);
            foreach (var team in viewModel.Teams)
            {
                team.Selected = associations.FirstOrDefault(x => x.TeamId == team.Id) != null;
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleNames.ROLE_ADMIN)]
        public IActionResult Edit(int? id, EventEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            if (id == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            var entry = _eventRepository.Find(x => x.Id == id).FirstOrDefault();

            // Update
            entry.Designation = viewModel.CurrentEvent.Designation;
            entry.Description = viewModel.CurrentEvent.Description;
            entry.Location = viewModel.CurrentEvent.Location;
            entry.Start = viewModel.CurrentEvent.Start;
            entry.End = viewModel.CurrentEvent.End;
            entry.MeetingLocation = viewModel.CurrentEvent.MeetingLocation;
            entry.MeetingTime = viewModel.CurrentEvent.MeetingTime;
            entry.SeatsRequired = viewModel.CurrentEvent.SeatsRequired;
            entry.PlayersRequired = viewModel.CurrentEvent.PlayersRequired;
            entry.CoachesRequired = viewModel.CurrentEvent.CoachesRequired;
            entry.ScorersRequired = viewModel.CurrentEvent.ScorersRequired;
            entry.UmpiresRequired = viewModel.CurrentEvent.UmpiresRequired;

            _eventAssociationRepository.Update(entry.Id, viewModel.Teams);

            _eventRepository.CommitChanges();

            return RedirectToAction("Administrate");
        }

        [Authorize(Roles = RoleNames.ROLE_ADMIN)]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            Event e = _eventRepository.Find(x => x.Id == id).FirstOrDefault();
            if (e == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            EventDeleteViewModel viewModel = new EventDeleteViewModel();
            viewModel.SelectedEvent = e;
            viewModel.UserParticipationCount = _participationRepository.Find(x => x.EventId == e.Id).Count();

            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.ROLE_ADMIN)]
        public IActionResult Delete(int id)
        {
            Event e = _eventRepository.Find(x => x.Id == id).FirstOrDefault();
            if (e == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            var participations = _participationRepository.Find(x => x.EventId == id);
            _participationRepository.RemoveRange(participations);
            _eventRepository.Remove(e);

            return RedirectToAction("Administrate");
        }

        [Authorize(Roles = RoleNames.ROLE_ADMIN)]
        public IActionResult Participations(int? id)
        {
            if (id == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            Event e = _eventRepository.Find(x => x.Id == id).FirstOrDefault();
            if (e == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            var participations = _participationRepository.Find(x => x.EventId == id).ToList();
            foreach(var participation in participations)
            {
                participation.Username = _userRepository.GetUsernameByUserId(participation.UserId);
            }

            EventParticipationViewModel viewModel = new EventParticipationViewModel();

            viewModel.EventParticipations = participations;
            viewModel.EventId = e.Id;
            viewModel.EventDesignation = e.Designation;
            viewModel.DisplayHasSeats = e.SeatsRequired > 0;
            viewModel.DisplayIsPlayer = e.PlayersRequired > 0;
            viewModel.DisplayIsCoach = e.CoachesRequired > 0;
            viewModel.DisplayIsUmpire = e.UmpiresRequired > 0;
            viewModel.DisplayIsScorer = e.ScorersRequired > 0;

            viewModel.SumParticipations = participations.Where(x => x.AnswerYes).Count();
            viewModel.SumCoaches = participations.Where(x => x.IsCoach).Count();
            viewModel.SumPlayers = participations.Where(x => x.IsPlayer).Count();
            viewModel.SumScorer = participations.Where(x => x.IsScorer).Count();
            viewModel.SumUmpires = participations.Where(x => x.IsUmpire).Count();
            viewModel.SumSeats = participations.Sum(x => x.Seats);
            viewModel.RequiredCoaches = e.CoachesRequired;
            viewModel.RequiredPlayers = e.PlayersRequired;
            viewModel.RequiredScorer = e.ScorersRequired;
            viewModel.RequiredUmpires = e.UmpiresRequired;
            viewModel.RequiredSeats = e.SeatsRequired;

            return View(viewModel);
        }
    }
}