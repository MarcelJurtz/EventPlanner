using ClubGrid.Enums;
using System.Collections.Generic;

namespace ClubGrid.ViewModels
{
    public class TeamRoleViewModel
    {
        public IEnumerable<TeamRole> Roles { get; set; }
        public TeamRole Role { get; set;  }
    }
}
