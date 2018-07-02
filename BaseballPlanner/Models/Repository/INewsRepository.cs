using ClubGrid.Models;
using System.Collections.Generic;

namespace Planner.Models.Repository
{
    public interface INewsRepository : IRepository<News>
    {
        IEnumerable<News> GetLastItems(int count);
    }
}
