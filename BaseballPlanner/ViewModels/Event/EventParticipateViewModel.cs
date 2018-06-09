using Planner.Models;
using Planner.Models.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Planner.ViewModels
{
    public class EventParticipateViewModel
    {
        public Event CurrentEvent { get; set; }

        //[DisplayName("Ich bin dabei!")]
        //public bool ParticipateYes { get; set; }

        //[DisplayName("Ich habe leider keine Zeit")]
        //public bool ParticipateNo { get; set; }

        //[DisplayName("Ich weiss es noch nicht")]
        //public bool ParticipateMaybe { get; set; }
        public ParticipationTypesEnum ParticipationType { get; set; }

        [DisplayName("Ich nehme als Spieler teil")]
        public bool IsPlayer { get; set; }
        public bool DisplayIsPlayer { get; set; }

        [DisplayName("Ich nehme als Coach teil")]
        public bool IsCoach { get; set; }
        public bool DisplayIsCoach { get; set; }

        [DisplayName("Ich nehme als Umpire teil")]
        public bool IsUmpire { get; set; }
        public bool DisplayIsUmpire { get; set; }

        [DisplayName("Ich nehme als Scorer teil")]
        public bool IsScorer { get; set; }
        public bool DisplayIsScorer { get; set; }

        [DisplayName("Ich kann fahren und habe (inklusive mir) Plätze")]
        public int HasSeats { get; set; }
        public bool DisplayHasSeats { get; set; }

        [StringLength(100, ErrorMessage = "Deine Nachricht kann maximal 100 Zeichen lang sein")]
        [DisplayName("Bemerkung")]
        public string Note { get; set; }
    }
}
