using ClubGrid.Models;
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

        public void Update(int eventId, IEnumerable<Team> teams)
        {
            var teamAssociations = _appDbContext.EventAssociations.Where(x => x.EventId == eventId);
            foreach (var team in teams)
            {
                var association = teamAssociations.FirstOrDefault(x => x.TeamId == team.Id);

                if (association != null && !team.Selected)
                    _appDbContext.EventAssociations.Remove(association);

                else if (association == null && team.Selected)
                {
                    var date = DateTime.Now;
                    association = new EventAssociation()
                    {
                        Created = date,
                        Modified = date,
                        TeamId = team.Id,
                        EventId = eventId
                    };
                    _appDbContext.EventAssociations.Add(association);
                }
            }
            CommitChanges();
        }

        public void CommitChanges()
        {
            _appDbContext.SaveChanges();
        }
    }
}
