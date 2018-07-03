using ClubGrid.Models;

namespace ClubGrid.ViewModels
{
    public class EventDeleteViewModel : BaseViewModel
    {
        public string Caption { get; set; }
        public Event SelectedEvent { get; set; }
        public int UserParticipationCount { get; set; }
    }
}
