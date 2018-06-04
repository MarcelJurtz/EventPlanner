using Planner.Models;
using System.Collections.Generic;

namespace Planner.ViewModels
{
    public class EventParticipationViewModel
    {
        public int EventId { get; set; }
        public string EventDesignation { get; set; }
        public List<EventParticipation> EventParticipations { get; set; }
        public bool DisplayIsPlayer { get; set; }
        public bool DisplayIsCoach { get; set; }
        public bool DisplayIsUmpire { get; set; }
        public bool DisplayIsScorer { get; set; }
        public bool DisplayHasSeats { get; set; }
    }
}
