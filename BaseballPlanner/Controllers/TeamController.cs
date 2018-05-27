using Microsoft.AspNetCore.Mvc;
using Planner.Models;
using Planner.Models.Repository;
using Planner.ViewModels;
using System.Linq;
using System.Net;

namespace BaseballPlanner.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamRepository _teamRepository;

        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
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

            return RedirectToAction("Index", "Team");
        }

        public IActionResult Edit(int? id)
        {
            TeamEditViewModel viewModel = new TeamEditViewModel();

            if (id == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            viewModel.CurrentTeam = _teamRepository.Find(x => x.Id == id).FirstOrDefault();
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

            found.Designation = viewModel.CurrentTeam.Designation;
            _teamRepository.CommitChanges();

            return RedirectToAction("Index", "Team");
        }

        public IActionResult Delete(int id)
        {
            _teamRepository.Remove(id);

            return RedirectToAction("Index", "Team");
        }
    }
}