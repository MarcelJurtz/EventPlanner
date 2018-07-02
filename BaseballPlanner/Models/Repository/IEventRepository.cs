using ClubGrid.Models;
using System.Collections.Generic;

namespace ClubGrid.Repository
{
    public interface IEventRepository : IRepository<Event>
    {
        IEnumerable<Event> GetAllForUser(int userId, bool upcomingOnly);
        IEnumerable<Event> GetUnreadForUser(int userId, bool upcomingOnly);
        IEnumerable<Event> GetHistoricalForUser(int userId);
    }
}
