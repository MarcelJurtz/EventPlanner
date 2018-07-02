using ClubGrid.Models;
using System.Collections.Generic;

namespace Planner.ViewModels
{
    public class EventListViewModel
    {
        public string[] TeamNames { get; set; }
        public IEnumerable<Event> Events { get; set; }
    }
}
