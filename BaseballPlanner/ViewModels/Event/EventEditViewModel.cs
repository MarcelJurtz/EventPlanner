using ClubGrid.Models;
using System.Collections.Generic;

namespace Planner.ViewModels
{
    public class EventEditViewModel
    {
        public Event CurrentEvent { get; set; }
        public List<Team> Teams { get; set; }
    }
}
