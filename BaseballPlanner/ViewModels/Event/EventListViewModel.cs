using System.Collections.Generic;

namespace Planner.ViewModels
{
    // ViewModels are useful when the view requires multiple properties
    public class EventListViewModel
    {
        public IEnumerable<Models.Event> Events { get; set; }
    }
}
