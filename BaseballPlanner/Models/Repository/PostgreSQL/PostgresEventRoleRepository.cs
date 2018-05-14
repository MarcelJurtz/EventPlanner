using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Planner.Models.Repository.PostgreSQL
{
    public class PostgresEventRoleRepository : IEventRoleRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostgresEventRoleRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public EventRole Get(int id)
        {
            return _appDbContext.EventRoles.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<EventRole> GetAll()
        {
            return _appDbContext.EventRoles;
        }

        public IEnumerable<EventRole> Find(Expression<Func<EventRole, bool>> predicate)
        {
            return _appDbContext.EventRoles.Where(predicate.Compile()).ToList();
        }

        public void Add(EventRole entity)
        {
            _appDbContext.EventRoles.Add(entity);
        }

        public void AddRange(IEnumerable<EventRole> entities)
        {
            _appDbContext.EventRoles.AddRange(entities);
        }

        public void Remove(EventRole entity)
        {
            _appDbContext.EventRoles.Remove(entity);
        }

        public void RemoveRange(IEnumerable<EventRole> entities)
        {
            _appDbContext.EventRoles.RemoveRange(entities);
        }
    }
}
