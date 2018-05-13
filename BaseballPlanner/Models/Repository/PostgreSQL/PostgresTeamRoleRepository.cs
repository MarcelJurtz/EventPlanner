using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Models.Repository.PostgreSQL
{
    public class PostgresTeamRoleRepository : ITeamRoleRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostgresTeamRoleRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public void AddRole(TeamRole role)
        {
            _appDbContext.TeamRoles.Add(role);
            _appDbContext.SaveChanges(); // TODO
        }

        public void DeleteRole(TeamRole role)
        {
            _appDbContext.TeamRoles.Remove(role);
        }

        public IEnumerable<TeamRole> TeamRoles
        {
            get { return _appDbContext.TeamRoles; }
        }

        public void ModifyRole(TeamRole role)
        {
            throw new NotImplementedException();
        }
    }
}
