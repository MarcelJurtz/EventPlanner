using ClubGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ClubGrid.Repository.PostgreSQL
{
    public class PostgresEventRepository : IEventRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostgresEventRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public void Add(Event entity, bool commit = true)
        {
            _appDbContext.Events.Add(entity);

            if (commit)
                CommitChanges();
        }

        public void AddRange(IEnumerable<Event> entities, bool commit = true)
        {
            _appDbContext.Events.AddRange(entities);

            if (commit)
                CommitChanges();
        }

        public IEnumerable<Event> Find(Expression<Func<Event, bool>> predicate)
        {
            return _appDbContext.Events.Where(predicate.Compile()).ToList();
        }

        public Event Get(int id)
        {
            return _appDbContext.Events.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Event> GetAll()
        {
            return _appDbContext.Events;
        }

        public void Remove(Event entity, bool commit = true)
        {
            _appDbContext.Events.Remove(entity);

            if (commit)
                CommitChanges();
        }

        public void RemoveRange(IEnumerable<Event> entities, bool commit = true)
        {
            _appDbContext.Events.RemoveRange(entities);

            if (commit)
                CommitChanges();
        }

        public void CommitChanges()
        {
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Event> GetAllForUser(int userId, bool upcomingOnly = false)
        {
            var teamIds = from t in _appDbContext.Teams
                          join association in _appDbContext.TeamAssociations
                          on t.Id equals association.TeamId
                          where (association.UserId == userId)
                          select t.Id;

            var results = from e in _appDbContext.Events
                          join association in _appDbContext.EventAssociations
                          on e.Id equals association.EventId
                          where (teamIds.Contains(association.TeamId))
                          select e;

            if (upcomingOnly)
                results = results.Where(e => e.Start > DateTime.Now);

            return results;           
        }

        // Gibt alle unbeantworteten Events zurück
        // Beinhaltet auch mit "vielleicht" beantwortete!
        public IEnumerable<Event> GetUnreadForUser(int userId, bool upcomingOnly = false)
        {
            var teamIds = from t in _appDbContext.Teams
                          join association in _appDbContext.TeamAssociations
                          on t.Id equals association.TeamId
                          where (association.UserId == userId)
                          select t.Id;

            var participations = from p in _appDbContext.EventParticipations
                                where p.UserId == userId && (p.AnswerYes || p.AnswerNo)
                                select p.EventId;

            var results = from e in _appDbContext.Events
                          join association in _appDbContext.EventAssociations
                          on e.Id equals association.EventId
                          where (teamIds.Contains(association.TeamId)) && !participations.Contains(e.Id)
                          select e;

            if (upcomingOnly)
                results = results.Where(e => e.Start >= DateTime.Now);

            return results;
        }

        public IEnumerable<Event> GetHistoricalForUser(int userId)
        {
            var teamIds = from t in _appDbContext.Teams
                          join association in _appDbContext.TeamAssociations
                          on t.Id equals association.TeamId
                          where (association.UserId == userId)
                          select t.Id;

            var results = from e in _appDbContext.Events
                          join association in _appDbContext.EventAssociations
                          on e.Id equals association.EventId
                          where (teamIds.Contains(association.TeamId)) && e.Start < DateTime.Now
                          select e;

            return results;
        }
    }
}
