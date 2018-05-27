using System.Collections.Generic;
using System.Security.Claims;

namespace Planner.Models.Repository
{
    public interface IEventRepository : IRepository<Event>
    {
        IEnumerable<Event> GetAllForUser(int userId);
    }
}
