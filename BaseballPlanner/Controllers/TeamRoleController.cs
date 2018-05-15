using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Planner.Models;
using Planner.Models.Repository;
using Planner.ViewModels;

namespace BaseballPlanner.Controllers
{
    [Authorize(Roles = "admin")]
    public class TeamRoleController : Controller
    {
        private readonly ITeamRoleRepository _teamRoleRepository;
        private TeamRoleViewModel vm;

        public TeamRoleController(ITeamRoleRepository teamRoleRepository)
        {
            _teamRoleRepository = teamRoleRepository;

            vm = new TeamRoleViewModel();
            vm.Roles = _teamRoleRepository.GetAll();
            vm.Role = new TeamRole();
        }

        public IActionResult Index()
        {
            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(TeamRole role)
        {
            if(ModelState.IsValid)
            {
                _teamRoleRepository.Add(role);
                return RedirectToAction("Index");
            }
            return View(vm);
        }
    }
}