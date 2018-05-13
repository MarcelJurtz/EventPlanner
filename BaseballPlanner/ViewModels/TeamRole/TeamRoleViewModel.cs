using Planner.Models;
using System.Collections.Generic;

namespace Planner.ViewModels
{
    public class TeamRoleViewModel
    {
        public IEnumerable<TeamRole> Roles { get; set; }
        public TeamRole Role { get; set;  }
    }
}
