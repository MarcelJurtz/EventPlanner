using System;
using System.Collections.Generic;

namespace Planner.Models.Repository.PostgreSQL
{
    public class PostgresEventRoleRepository : IEventRoleRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostgresEventRoleRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public void AddEventRole(EventRole role)
        {
            _appDbContext.EventRoles.Add(role);
        }

        public void DeleteEventRole(EventRole role)
        {
            _appDbContext.EventRoles.Remove(role);
        }

        public IEnumerable<EventRole> EventRoles
        {
            get { return _appDbContext.EventRoles; }
        }

        public void ModifyEventRole(EventRole role)
        {
            throw new NotImplementedException();
        }
    }
}
