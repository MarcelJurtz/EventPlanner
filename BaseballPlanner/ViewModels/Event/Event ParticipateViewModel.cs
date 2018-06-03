using Planner.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Planner.ViewModels
{
    public class Event_ParticipateViewModel
    {
        public Event CurrentEvent { get; set; }

        [DisplayName("Ich bin dabei!")]
        public bool Yes { get; set; }

        [DisplayName("Ich habe leider keine Zeit")]
        public bool No { get; set; }

        [DisplayName("Ich weiss es noch nicht")]
        public bool Maybe { get; set; }

        [StringLength(100, ErrorMessage = "Deine Nachricht kann maximal 100 Zeichen lang sein")]
        [DisplayName("Bemerkung")]
        public string Note { get; set; }
    }
}
