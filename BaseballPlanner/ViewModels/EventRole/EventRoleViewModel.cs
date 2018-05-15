using Planner.Models;
using System.Collections.Generic;

namespace Planner.ViewModels
{
    public class EventRoleViewModel
    {
        public IEnumerable<EventRole> Roles { get; set; }
        public EventRole Role { get; set; }
    }
}
