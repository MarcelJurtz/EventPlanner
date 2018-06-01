using Planner.Models;
using System.Collections.Generic;

namespace Planner.ViewModels
{
    public class UserEditViewModel
    {
        public User CurrentUser { get; set; }
        public List<Team> AllTeams { get; set; }
        public bool IsAdmin { get; set; }
    }
}
