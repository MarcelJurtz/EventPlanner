using Planner.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Planner.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<IGrouping<DateTime, News>> News {get;set;}
    }
}