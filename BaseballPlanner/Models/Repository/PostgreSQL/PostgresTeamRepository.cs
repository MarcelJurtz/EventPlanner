using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Models.Repository.PostgreSQL
{
    public class PostgresTeamRepository : ITeamRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostgresTeamRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public IEnumerable<Team> Teams
        {
            get
            {
                return _appDbContext.Teams;
            }
        }

        public void AddTeam(Team team)
        {
            _appDbContext.Teams.Add(team);
        }

        public void DeleteTeam(Team team)
        {
            _appDbContext.Teams.Remove(team);
        }

        public void ModifyTeam(Team team)
        {
            throw new NotImplementedException();
        }
    }
}
