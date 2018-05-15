using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Models
{
    /// <summary>
    /// Define the type of participation
    /// For example: Player, Driver, ...
    /// </summary>
    public class EventRole
    {
        [BindNever]
        public int Id { get; set; }

        [DisplayName("Bezeichnung")]
        [Required(ErrorMessage = "Bitte geben Sie eine Bezeichnung an")]
        [StringLength(25)]
        public string Designation { get; set; }

        [DisplayName("Benötigte Anzahl")]
        [Required(ErrorMessage = "Bitte geben Sie eine Anzahl an")]
        public int? QuantityRequired { get; set; }

        /// <summary>
        /// Use this to define sub-items where the quantity of the role itself does not matter
        /// For example: Quantity of seats - Quantity of drivers is variable
        /// </summary>
        [DisplayName("Untergeordnete Bezeichnung")]
        [StringLength(25)]
        public string SubDesignation { get; set; }

        [DisplayName("Benötigte untergeordnete Anzahl")]
        public int? SubQuantityRequired { get; set; }
    }
}
