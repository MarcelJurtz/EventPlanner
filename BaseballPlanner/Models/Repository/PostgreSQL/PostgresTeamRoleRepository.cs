using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Planner.Models.Repository.PostgreSQL
{
    public class PostgresTeamRoleRepository : ITeamRoleRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostgresTeamRoleRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public void Add(TeamRole entity)
        {
            _appDbContext.TeamRoles.Add(entity);
        }

        public void AddRange(IEnumerable<TeamRole> entities)
        {
            _appDbContext.TeamRoles.AddRange(entities);
        }

        public IEnumerable<TeamRole> Find(Expression<Func<TeamRole, bool>> predicate)
        {
            return _appDbContext.TeamRoles.Where(predicate.Compile()).ToList();
        }

        public TeamRole Get(int id)
        {
            return _appDbContext.TeamRoles.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TeamRole> GetAll()
        {
            return _appDbContext.TeamRoles;
        }

        public void Remove(TeamRole entity)
        {
            _appDbContext.TeamRoles.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TeamRole> entities)
        {
            _appDbContext.TeamRoles.RemoveRange(entities);
        }
    }
}
