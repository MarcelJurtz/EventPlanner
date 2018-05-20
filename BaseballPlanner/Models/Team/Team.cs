using System;
using System.ComponentModel.DataAnnotations;

namespace Planner.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Designation { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
