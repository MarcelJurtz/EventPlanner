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

        public void Add(EventParticipation entity, bool commit = true)
        {
            _appDbContext.EventParticipations.Add(entity);

            if (commit)
                CommitChanges();
        }

        public void AddRange(IEnumerable<EventParticipation> entities, bool commit = true)
        {
            _appDbContext.EventParticipations.AddRange(entities);

            if (commit)
                CommitChanges();
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

        public void Remove(EventParticipation entity, bool commit = true)
        {
            _appDbContext.EventParticipations.Remove(entity);

            if (commit)
                CommitChanges();
        }

        public void RemoveRange(IEnumerable<EventParticipation> entities, bool commit = true)
        {
            _appDbContext.EventParticipations.RemoveRange(entities);

            if (commit)
                CommitChanges();
        }

        public void Update(int eventId, int userId, bool yes, bool no, string note)
        {
            var date = DateTime.Now;
            EventParticipation p = _appDbContext.EventParticipations.Where(x => x.EventId == eventId && x.UserId == userId).FirstOrDefault();

            if(p == null)
            {
                p = new EventParticipation();
                p.Created = date;
                p.UserId = userId;
                p.EventId = eventId;
                _appDbContext.EventParticipations.Add(p);
            }

            p.Modified = date;

            p.AnswerYes = yes;
            p.AnswerNo = no;
            p.Note = note;

            //p.IsPlayer = participation.IsPlayer;
            //p.IsCoach = participation.IsCoach;
            //p.IsScorer = participation.IsScorer;
            //p.IsUmpire = participation.IsUmpire;

            CommitChanges();
        }

        public void CommitChanges()
        {
            _appDbContext.SaveChanges();
        }
    }
}
