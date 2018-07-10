using ClubGrid.Helper;
using ClubGrid.Models;
using ClubGrid.Repository;
using ClubGrid.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace ClubGrid.Controllers
{
    [Authorize(Roles = RoleNames.ROLE_ADMIN)]
    public class TeamController : Controller
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ITeamAssociationRepository _teamAssociationRepository;
        private readonly IUserRepository _userRepository;

        public TeamController(ITeamRepository teamRepository, ITeamAssociationRepository teamAssociationRepository, IUserRepository userRepository)
        {
            _teamRepository = teamRepository;
            _teamAssociationRepository = teamAssociationRepository;
            _userRepository = userRepository;
        }

        public ViewResult Index()
        {
            TeamIndexViewModel viewModel = new TeamIndexViewModel();
            viewModel.Teams = _teamRepository.GetAll();
            return View(viewModel);
        }

        public ViewResult Add()
        {
            TeamEditViewModel viewModel = new TeamEditViewModel();
            viewModel.CurrentTeam = new Team();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Add(TeamEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            if (_teamRepository.Find(x => x.Designation == viewModel.CurrentTeam.Designation).FirstOrDefault() != null)
                return View(viewModel);

            _teamRepository.Add(viewModel.CurrentTeam);

            return RedirectToAction(MethodNames.INDEX);
        }

        public IActionResult Edit(int? id)
        {
            TeamEditViewModel viewModel = new TeamEditViewModel();

            if (id == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            viewModel.CurrentTeam = _teamRepository.Find(x => x.Id == id).FirstOrDefault();
            viewModel.AllUsers = _userRepository.GetAll().ToList();

            var associations = _teamAssociationRepository.Find(x => x.TeamId == id);
            foreach (var user in viewModel.AllUsers)
            {
                user.Selected = associations.FirstOrDefault(x => x.UserId == user.UserId) != null;
            }

            if (viewModel.CurrentTeam == null)
                return StatusCode((int)HttpStatusCode.NotFound);
            else
                return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, TeamEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            if (id == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            var found = _teamRepository.Find(x => x.Id == id).FirstOrDefault();

            if (found == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            _teamAssociationRepository.Update((int)id, viewModel.AllUsers);

            found.Designation = viewModel.CurrentTeam.Designation;
            _teamRepository.CommitChanges();

            return RedirectToAction(MethodNames.INDEX);
        }

        [Authorize(Roles = RoleNames.ROLE_ADMIN)]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            Team team = _teamRepository.Find(x => x.Id == id).FirstOrDefault();
            if (team == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            TeamDeleteViewModel viewModel = new TeamDeleteViewModel();
            viewModel.Team = team;
            viewModel.TeamAssociationCount = _teamAssociationRepository.Find(x => x.TeamId == team.Id).Count();

            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.ROLE_ADMIN)]
        public IActionResult Delete(int id)
        {
            Team team = _teamRepository.Find(x => x.Id == id).FirstOrDefault();
            if (team == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            var associations = _teamAssociationRepository.Find(x => x.TeamId == id);
            _teamAssociationRepository.RemoveRange(associations);
            _teamRepository.Remove(team);

            return RedirectToAction(MethodNames.INDEX);
        }
    }
}