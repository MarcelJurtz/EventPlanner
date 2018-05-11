using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Models.Repository.PostgreSQL
{
    public class PostgresEventRepository : IEventRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostgresEventRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public void AddEvent(Event e)
        {
            _appDbContext.Events.Add(e);
        }

        public void DeleteEvent(Event e)
        {
            _appDbContext.Events.Remove(e);
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _appDbContext.Events;
        }

        public Event GetEventById(int id)
        {
            return _appDbContext.Events.FirstOrDefault(x => x.Id == id);
        }

        public void ModifyEvent(Event e)
        {
            throw new NotImplementedException();
        }
    }
}
