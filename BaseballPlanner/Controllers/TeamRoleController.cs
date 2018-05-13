using Microsoft.AspNetCore.Mvc;
using Planner.Models.Repository;

namespace BaseballPlanner.Controllers
{
    public class TeamRoleController : Controller
    {
        private readonly ITeamRoleRepository _teamRoleRepository;

        public TeamRoleController(ITeamRoleRepository teamRoleRepository)
        {
            _teamRoleRepository = teamRoleRepository;
        }

        public IActionResult Index()
        {
            return View(_teamRoleRepository.TeamRoles);
        }
    }
}