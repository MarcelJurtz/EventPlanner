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

        public void Add(TeamAssociation entity, bool commit = true)
        {
            _appDbContext.TeamAffiliations.Add(entity);

            if (commit)
                CommitChanges();
        }

        public void AddRange(IEnumerable<TeamAssociation> entities, bool commit = true)
        {
            _appDbContext.TeamAffiliations.AddRange(entities);

            if (commit)
                CommitChanges();
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

        public void Remove(TeamAssociation entity, bool commit = true)
        {
            _appDbContext.TeamAffiliations.Remove(entity);

            if (commit)
                CommitChanges();
        }

        public void RemoveRange(IEnumerable<TeamAssociation> entities, bool commit = true)
        {
            _appDbContext.TeamAffiliations.RemoveRange(entities);

            if (commit)
                CommitChanges();
        }

        public void CommitChanges()
        {
            _appDbContext.SaveChanges();
        }
    }
}
