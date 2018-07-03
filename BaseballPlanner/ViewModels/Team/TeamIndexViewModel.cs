using ClubGrid.Models;
using System.Collections.Generic;

namespace ClubGrid.ViewModels
{
    public class TeamIndexViewModel : BaseViewModel
    {
        public IEnumerable<Team> Teams { get; set; }
    }
}
