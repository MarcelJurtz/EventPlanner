using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Planner.Models.Repository.PostgreSQL
{
    public class PostgresTeamAssociationRepository : ITeamAssociationRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostgresTeamAssociationRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public void Add(TeamAssociation entity)
        {
            _appDbContext.TeamAffiliations.Add(entity);
            _appDbContext.SaveChanges();
        }

        public void AddRange(IEnumerable<TeamAssociation> entities)
        {
            _appDbContext.TeamAffiliations.AddRange(entities);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<TeamAssociation> Find(Expression<Func<TeamAssociation, bool>> predicate)
        {
            return _appDbContext.TeamAffiliations.Where(predicate.Compile()).ToList();
        }

        public TeamAssociation Get(int id)
        {
            return _appDbContext.TeamAffiliations.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TeamAssociation> GetAll()
        {
            return _appDbContext.TeamAffiliations;
        }

        public void Remove(TeamAssociation entity)
        {
            _appDbContext.TeamAffiliations.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public void RemoveRange(IEnumerable<TeamAssociation> entities)
        {
            _appDbContext.TeamAffiliations.RemoveRange(entities);
            _appDbContext.SaveChanges();
        }
    }
}
