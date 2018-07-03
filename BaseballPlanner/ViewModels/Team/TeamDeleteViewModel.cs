using ClubGrid.Models;

namespace ClubGrid.ViewModels
{
    public class TeamDeleteViewModel : BaseViewModel
    {
        public Team Team { get; set; }
        public int TeamAssociationCount { get; set; }
    }
}
