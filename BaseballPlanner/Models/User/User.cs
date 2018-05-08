using System.Collections.Generic;

namespace Planner.Models
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EMail { get; set; }

        public Dictionary<Team, TeamRole> TeamAffiliations { get; set; }
    }
}
