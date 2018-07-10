using ClubGrid.Models;
using System.Collections.Generic;

namespace ClubGrid.ViewModels
{
    public class TeamEditViewModel : BaseViewModel
    { 
        public Team CurrentTeam { get; set; }
        public List<User> AllUsers { get; set; }
    }
}
