using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Models.Repository.PostgreSQL
{
    public class PostgresTeamAffiliationRepository : ITeamAffiliationRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostgresTeamAffiliationRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public IEnumerable<TeamAffiliation> TeamAffiliations
        {
            get { return _appDbContext.TeamAffiliations; }
        }

        public void AddTeamAffiliation(TeamAffiliation teamAffiliation)
        {
            _appDbContext.TeamAffiliations.Add(teamAffiliation);
        }

        public void RemoveTeamAffiliation(TeamAffiliation teamAffiliation)
        {
            _appDbContext.TeamAffiliations.Remove(teamAffiliation);
        }
    }
}
