using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.Models
{
    public class EventAssociation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }

        public Team Team { get; set; }

        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }

        public Event Event { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
