using ClubGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubGrid.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<IGrouping<DateTime, News>> News {get;set;}
    }
}