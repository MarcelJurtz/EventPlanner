using Planner.Models;
using System.Collections.Generic;

namespace Planner.ViewModels
{
    public class EventListViewModel
    {
        public string[] TeamNames { get; set; }
        public IEnumerable<Models.Event> Events { get; set; }
    }
}
