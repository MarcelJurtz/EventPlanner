using Planner.Models;
using System.Collections.Generic;

namespace Planner.ViewModels
{
    public class UserEditViewModel
    {
        public User CurrentUser { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public bool IsAdmin { get; set; }
    }
}
