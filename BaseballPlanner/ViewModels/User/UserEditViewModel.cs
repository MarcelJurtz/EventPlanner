using ClubGrid.Models;
using System.Collections.Generic;

namespace ClubGrid.ViewModels
{
    public class UserEditViewModel : BaseViewModel
    {
        public User CurrentUser { get; set; }
        public List<Team> AllTeams { get; set; }
        public bool IsAdmin { get; set; }
    }
}
