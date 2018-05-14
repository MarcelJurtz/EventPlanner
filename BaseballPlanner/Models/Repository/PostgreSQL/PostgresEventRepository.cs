using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Planner.Models.Repository.PostgreSQL
{
    public class PostgresEventRepository : IEventRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostgresEventRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public void Add(Event entity)
        {
            _appDbContext.Events.Add(entity);
        }

        public void AddRange(IEnumerable<Event> entities)
        {
            _appDbContext.Events.AddRange(entities);
        }

        public IEnumerable<Event> Find(Expression<Func<Event, bool>> predicate)
        {
            return _appDbContext.Events.Where(predicate.Compile()).ToList();
        }

        public Event Get(int id)
        {
            return _appDbContext.Events.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Event> GetAll()
        {
            return _appDbContext.Events;
        }

        public void Remove(Event entity)
        {
            _appDbContext.Events.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Event> entities)
        {
            _appDbContext.Events.RemoveRange(entities);
        }
    }
}
