using ClubGrid.Models;
using System.Collections.Generic;

namespace ClubGrid.ViewModels
{
    public class EventEditViewModel : BaseViewModel
    {
        public Event CurrentEvent { get; set; }
        public List<Team> Teams { get; set; }
    }
}
