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

        public void Add(Event entity, bool commit = true)
        {
            _appDbContext.Events.Add(entity);

            if (commit)
                CommitChanges();
        }

        public void AddRange(IEnumerable<Event> entities, bool commit = true)
        {
            _appDbContext.Events.AddRange(entities);

            if (commit)
                CommitChanges();
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

        public void Remove(Event entity, bool commit = true)
        {
            _appDbContext.Events.Remove(entity);

            if (commit)
                CommitChanges();
        }

        public void RemoveRange(IEnumerable<Event> entities, bool commit = true)
        {
            _appDbContext.Events.RemoveRange(entities);

            if (commit)
                CommitChanges();
        }

        public void CommitChanges()
        {
            _appDbContext.SaveChanges();
        }
    }
}
