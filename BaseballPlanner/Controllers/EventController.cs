using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Planner.Models.Repository;
using Planner.ViewModels;
using System.Linq;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Planner.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;

        // Constructor parameters will be injected 
        // because the objects have been registered in startup.cs
        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        // ActionResults
        public ViewResult Index() // Action
        {
            EventListViewModel viewModel = new EventListViewModel();
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier);
            viewModel.Events = _eventRepository.GetAll();
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
                return RedirectToAction("Index", "Event");
        }
    }
}
