using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Planner.Models.Repository.PostgreSQL
{
    public class PostgresEventParticipationRepository : IEventParticipationRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostgresEventParticipationRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public void Add(EventParticipation entity)
        {
            _appDbContext.EventParticipations.Add(entity);
            _appDbContext.SaveChanges();
        }

        public void AddRange(IEnumerable<EventParticipation> entities)
        {
            _appDbContext.EventParticipations.AddRange(entities);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<EventParticipation> Find(Expression<Func<EventParticipation, bool>> predicate)
        {
            return _appDbContext.EventParticipations.Where(predicate.Compile()).ToList();
        }

        public EventParticipation Get(int id)
        {
            return _appDbContext.EventParticipations.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<EventParticipation> GetAll()
        {
            return _appDbContext.EventParticipations;
        }

        public void Remove(EventParticipation entity)
        {
            _appDbContext.EventParticipations.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public void RemoveRange(IEnumerable<EventParticipation> entities)
        {
            _appDbContext.EventParticipations.RemoveRange(entities);
            _appDbContext.SaveChanges();
        }
    }
}
