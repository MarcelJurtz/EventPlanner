using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Planner.Models;
using Planner.Models.Repository;
using Planner.ViewModels;

namespace BaseballPlanner.Controllers
{
    [Authorize(Roles = "admin")]
    public class EventRoleController : Controller
    {
        private readonly IEventRoleRepository _eventRoleRepository;
        private EventRoleViewModel vm;

        public EventRoleController(IEventRoleRepository eventRoleRepository)
        {
            _eventRoleRepository = eventRoleRepository;

            vm = new EventRoleViewModel();
            vm.Roles = _eventRoleRepository.GetAll();
            vm.Role = new EventRole();
        }

        public IActionResult Index()
        {
            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(EventRole role)
        {
            if (ModelState.IsValid)
            {
                _eventRoleRepository.Add(role);
                return RedirectToAction("Index");
            }
            return View(vm);
        }
    }
}