using ClubGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ClubGrid.Repository.PostgreSQL
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

        public void Update(int userId, IEnumerable<Team> teams)
        {
            var userAssociations = _appDbContext.TeamAssociations.Where(x => x.UserId == userId);
            foreach(var team in teams)
            {
                var association = userAssociations.FirstOrDefault(x => x.UserId == userId && x.TeamId == team.Id);

                if (association != null && !team.Selected)
                    _appDbContext.TeamAssociations.Remove(association);
                else if(association == null && team.Selected)
                {
                    var date = DateTime.Now;
                    association = new TeamAssociation()
                    {
                        Created = date,
                        Modified = date,
                        TeamId = team.Id,
                        UserId = userId
                    };
                    _appDbContext.TeamAssociations.Add(association);
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
