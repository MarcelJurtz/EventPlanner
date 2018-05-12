using System.Collections.Generic;

namespace Planner.Models
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EMail { get; set; }

        public IEnumerable<TeamAffiliation> TeamAffiliations { get; set; }
    }
}
