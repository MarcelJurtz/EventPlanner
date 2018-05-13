using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Planner.Models
{
    /// <summary>
    /// Defines a specific persons role in a team
    /// eg. player, coach
    /// </summary>
    public class TeamRole
    {
        [BindNever]
        public int Id { get; set; }

        [DisplayName("Bezeichnung")]
        [Required(ErrorMessage = "Bitte geben Sie eine Bezeichnung an")]
        [StringLength(25)]
        public string Designation { get; set; }
    }
}
