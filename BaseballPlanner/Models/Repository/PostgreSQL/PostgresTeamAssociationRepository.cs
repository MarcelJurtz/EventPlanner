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
            _appDbContext.TeamAssociations.Add(entity);

            if (commit)
                CommitChanges();
        }

        public void AddRange(IEnumerable<TeamAssociation> entities, bool commit = true)
        {
            _appDbContext.TeamAssociations.AddRange(entities);

            if (commit)
                CommitChanges();
        }

        public IEnumerable<TeamAssociation> Find(Expression<Func<TeamAssociation, bool>> predicate)
        {
            return _appDbContext.TeamAssociations.Where(predicate.Compile()).ToList();
        }

        public TeamAssociation Get(int id)
        {
            return _appDbContext.TeamAssociations.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TeamAssociation> GetAll()
        {
            return _appDbContext.TeamAssociations;
        }

        public void Remove(TeamAssociation entity, bool commit = true)
        {
            _appDbContext.TeamAssociations.Remove(entity);

            if (commit)
                CommitChanges();
        }

        public void RemoveRange(IEnumerable<TeamAssociation> entities, bool commit = true)
        {
            _appDbContext.TeamAssociations.RemoveRange(entities);

            if (commit)
                CommitChanges();
        }

        public void CommitChanges()
        {
            _appDbContext.SaveChanges();
        }
    }
}
