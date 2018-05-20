using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.Models
{
    public class EventParticipation
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }

        public Event Event { get; set; }

        public int Seats { get; set; }

        public bool IsPlayer { get; set; }

        public bool IsCoach { get; set; }

        public bool IsUmpire { get; set; }

        public bool IsScorer { get; set; }

        [StringLength(100)]
        public string Note { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
