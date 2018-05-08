using System;
using System.Collections.Generic;
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
        public int Id { get; set; }
        public string Designation { get; set; }
        public int? QuantityRequired { get; set; }

        /// <summary>
        /// Use this to define sub-items where the quantity of the role itself does not matter
        /// For example: Quantity of seats - Quantity of drivers is variable
        /// </summary>
        public string SubDesignation { get; set; }
        public int? SubQuantityRequired { get; set; }
    }
}
