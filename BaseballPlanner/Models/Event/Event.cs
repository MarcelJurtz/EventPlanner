using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Planner.Models
{
    public class Event
    {
        [BindNever]
        public int Id { get; set; }

        [DisplayName("Bezeichnung")]
        [Required(ErrorMessage = "Bitte geben Sie eine Bezeichnung an")]
        [StringLength(100)]
        public string Designation { get; set; }

        [DisplayName("Beschreibung")]
        [StringLength(500)]
        public string Description { get; set; }

        [DisplayName("Ort")]
        [StringLength(50)]
        public string Location { get; set; }

        [DisplayName("Start")]
        [Required(ErrorMessage = "Bitte geben Sie einen Startzeitpunkt an")]
        public DateTime Start { get; set; }

        [DisplayName("Ende")]
        public DateTime? End { get; set; }

        [DisplayName("Treffpunkt")]
        [StringLength(100)]
        public string MeetingLocation { get; set; }

        [DisplayName("Treffpunkt Uhrzeit")]
        public DateTime MeetingTime { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
