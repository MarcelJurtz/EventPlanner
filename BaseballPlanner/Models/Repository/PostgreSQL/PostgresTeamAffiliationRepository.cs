using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public void Add(TeamAffiliation entity)
        {
            _appDbContext.TeamAffiliations.Add(entity);
        }

        public void AddRange(IEnumerable<TeamAffiliation> entities)
        {
            _appDbContext.TeamAffiliations.AddRange(entities);
        }

        public IEnumerable<TeamAffiliation> Find(Expression<Func<TeamAffiliation, bool>> predicate)
        {
            return _appDbContext.TeamAffiliations.Where(predicate.Compile()).ToList();
        }

        public TeamAffiliation Get(int id)
        {
            return _appDbContext.TeamAffiliations.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TeamAffiliation> GetAll()
        {
            return _appDbContext.TeamAffiliations;
        }

        public void Remove(TeamAffiliation entity)
        {
            _appDbContext.TeamAffiliations.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TeamAffiliation> entities)
        {
            _appDbContext.TeamAffiliations.RemoveRange(entities);
        }
    }
}
