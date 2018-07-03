using ClubGrid.Models;
using System.Collections.Generic;

namespace ClubGrid.ViewModels
{
    public class UserIndexViewModel : BaseViewModel
    {
        public IEnumerable<User> Users { get; set; }
    }
}
