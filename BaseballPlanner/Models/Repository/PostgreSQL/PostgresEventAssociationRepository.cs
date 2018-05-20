using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Planner.Models.Repository.PostgreSQL
{
    public class PostgresEventAssociationRepository : IEventAssociationRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostgresEventAssociationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(EventAssociation entity, bool commit = true)
        {
            _appDbContext.EventAssociations.Add(entity);

            if (commit)
                CommitChanges();
        }

        public void AddRange(IEnumerable<EventAssociation> entities, bool commit = true)
        {
            _appDbContext.EventAssociations.AddRange(entities);

            if (commit)
                CommitChanges();
        }

        public IEnumerable<EventAssociation> Find(Expression<Func<EventAssociation, bool>> predicate)
        {
            return _appDbContext.EventAssociations.Where(predicate.Compile()).ToList();
        }

        public EventAssociation Get(int id)
        {
            return _appDbContext.EventAssociations.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<EventAssociation> GetAll()
        {
            return _appDbContext.EventAssociations;
        }

        public void Remove(EventAssociation entity, bool commit = true)
        {
            _appDbContext.EventAssociations.Remove(entity);

            if (commit)
                CommitChanges();
        }

        public void RemoveRange(IEnumerable<EventAssociation> entities, bool commit = true)
        {
            _appDbContext.EventAssociations.RemoveRange(entities);

            if (commit)
                CommitChanges();
        }

        public void CommitChanges()
        {
            _appDbContext.SaveChanges();
        }
    }
}
