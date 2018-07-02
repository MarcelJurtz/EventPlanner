using ClubGrid.Models;
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

        public int SumParticipations { get; set; }
        public int SumPlayers { get; set; }
        public int SumCoaches { get; set; }
        public int SumUmpires { get; set; }
        public int SumScorer { get; set; }
        public int SumSeats { get; set; }

        public int RequiredPlayers { get; set; }
        public int RequiredCoaches { get; set; }
        public int RequiredUmpires { get; set; }
        public int RequiredScorer { get; set; }
        public int RequiredSeats { get; set; }
    }
}
