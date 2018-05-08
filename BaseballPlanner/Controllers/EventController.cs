using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Planner.Models.Repository;
using Planner.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Planner.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventRoleRepository _eventRoleRepository;

        // Constructor parameters will be injected 
        // because the objects have been registered in startup.cs
        public EventController(IEventRepository eventRepository, IEventRoleRepository eventRoleRepository)
        {
            _eventRepository = eventRepository;
            _eventRoleRepository = eventRoleRepository;
        }

        // ActionResults
        public ViewResult List() // Action
        {
            EventListViewModel viewModel = new EventListViewModel();
            viewModel.Events = _eventRepository.GetAllEvents();
            return View(viewModel); // View to Show -> Render default view for this method action
            // Default View: Controller will search in View-Subfolder for View with same name as the controller
            // Passing Parameters to View results in a strongly typed view. Alternative: Razor / ViewBag-Property
        }
    }
}
