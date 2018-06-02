using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Planner.Models;
using Planner.Models.Helper;
using Planner.Models.Repository;
using Planner.ViewModels;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Planner.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IEventParticipationRepository _participationRepository;
        private readonly UserManager<User> _userManager;

        // Constructor parameters will be injected 
        // because the objects have been registered in startup.cs
        public EventController(IEventRepository eventRepository, ITeamRepository teamRepository, IEventParticipationRepository participationRepository, UserManager<User> usermanager)
        {
            _eventRepository = eventRepository;
            _teamRepository = teamRepository;
            _participationRepository = participationRepository;
            _userManager = usermanager;
        }

        // ActionResults
        public async Task<ViewResult> Index() // Action
        {
            EventListViewModel viewModel = new EventListViewModel();
            //var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.GetUserAsync(this.User);
            viewModel.TeamNames = _teamRepository.GetForUser(user.UserId).Select(t => t.Designation).ToArray();
            viewModel.Events = _eventRepository.GetAllForUser(user.UserId);
            return View(viewModel); // View to Show -> Render default view for this method action
            // Default View: Controller will search in View-Subfolder for View with same name as the controller
            // Passing Parameters to View results in a strongly typed view. Alternative: Razor / ViewBag-Property
        }

        public ViewResult Add()
        {
            EventEditViewModel viewModel = new EventEditViewModel();
            viewModel.CurrentEvent = new Models.Event();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(EventEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            viewModel.CurrentEvent.Created = DateTime.Now;
            _eventRepository.Add(viewModel.CurrentEvent);

            return RedirectToAction("Index", "Event");
        }

        public IActionResult Participate(int id)
        {
            Models.Event e = _eventRepository.Find(x => x.Id == id).FirstOrDefault();

            // TODO Authentication

            if (e != null)
                return View(e);
            else
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

            Event e = _eventRepository.Find(x => x.Id == id).FirstOrDefault();
            if (e == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            return View(e);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleNames.ROLE_ADMIN)]
        public IActionResult Edit(int? id, Event e)
        {
            if (!ModelState.IsValid)
                return View(e);

            if (id == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            var entry = _eventRepository.Find(x => x.Id == id).FirstOrDefault();

            // Update
            entry.Designation = e.Designation;
            entry.Description = e.Description;
            entry.Location = e.Location;
            entry.Start = e.Start;
            entry.End = e.End;
            entry.MeetingLocation = e.MeetingLocation;
            entry.MeetingTime = e.MeetingTime;
            entry.SeatsRequired = e.SeatsRequired;
            entry.PlayersRequired = e.PlayersRequired;
            entry.CoachesRequired = e.CoachesRequired;
            entry.ScorersRequired = e.ScorersRequired;
            entry.UmpiresRequired = e.UmpiresRequired;

            _eventRepository.CommitChanges();

            return RedirectToAction("Index");
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
            viewModel.ParticipatingUsers = _participationRepository.Find(x => x.EventId == e.Id).Count();

            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.ROLE_ADMIN)]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            Event e = _eventRepository.Find(x => x.Id == id).FirstOrDefault();
            if (e == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            var participations = _participationRepository.Find(x => x.EventId == id);
            _participationRepository.RemoveRange(participations);
            _eventRepository.Remove(e);

            return RedirectToAction("Administrate");
        }
    }
}
