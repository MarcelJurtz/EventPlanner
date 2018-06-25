using System.Collections.Generic;

namespace Planner.Models.Repository
{
    public interface IEventRepository : IRepository<Event>
    {
        IEnumerable<Event> GetAllForUser(int userId, bool upcomingOnly);
        IEnumerable<Event> GetUnreadForUser(int userId, bool upcomingOnly);
    }
}
