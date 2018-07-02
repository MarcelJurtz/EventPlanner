using ClubGrid.Models;
using System.Collections.Generic;

namespace ClubGrid.Repository
{
    public interface INewsRepository : IRepository<News>
    {
        IEnumerable<News> GetLastItems(int count);
    }
}
