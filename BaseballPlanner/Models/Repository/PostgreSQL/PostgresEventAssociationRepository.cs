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

        public void Add(EventAssociation entity)
        {
            _appDbContext.EventAssociations.Add(entity);
            _appDbContext.SaveChanges();
        }

        public void AddRange(IEnumerable<EventAssociation> entities)
        {
            _appDbContext.EventAssociations.AddRange(entities);
            _appDbContext.SaveChanges();
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

        public void Remove(EventAssociation entity)
        {
            _appDbContext.EventAssociations.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public void RemoveRange(IEnumerable<EventAssociation> entities)
        {
            _appDbContext.EventAssociations.RemoveRange(entities);
            _appDbContext.SaveChanges();
        }
    }
}
