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
            _appDbContext.Teams.First(t => t.Id == entity.TeamId).UserCount += 1;

            if (commit)
                CommitChanges();
        }

        public void AddRange(IEnumerable<TeamAssociation> entities, bool commit = true)
        {
            _appDbContext.TeamAssociations.AddRange(entities);
            foreach (var entity in entities)
            {
                _appDbContext.Teams.First(t => t.Id == entity.TeamId).UserCount += 1;
            }

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
            _appDbContext.Teams.First(t => t.Id == entity.TeamId).UserCount -= 1;

            if (commit)
                CommitChanges();
        }

        public void RemoveRange(IEnumerable<TeamAssociation> entities, bool commit = true)
        {
            _appDbContext.TeamAssociations.RemoveRange(entities);
            foreach(var entity in entities)
            {
                _appDbContext.Teams.First(t => t.Id == entity.TeamId).UserCount -= 1;
            }

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
                {
                    _appDbContext.TeamAssociations.Remove(association);
                    _appDbContext.Teams.First(t => t.Id == team.Id).UserCount -= 1;
                }
                else if (association == null && team.Selected)
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
                    _appDbContext.Teams.First(t => t.Id == team.Id).UserCount += 1;
                }
            }
            CommitChanges();
        }

        public void Update(int teamId, IEnumerable<User> users)
        {
            var userAssociations = _appDbContext.TeamAssociations.Where(x => x.TeamId == teamId);
            foreach (var user in users)
            {
                var association = userAssociations.FirstOrDefault(x => x.UserId == user.UserId && x.TeamId == teamId);

                if (association != null && !user.Selected)
                {
                    _appDbContext.TeamAssociations.Remove(association);
                    _appDbContext.Teams.First(t => t.Id == teamId).UserCount -= 1;
                }
                else if (association == null && user.Selected)
                {
                    var date = DateTime.Now;
                    association = new TeamAssociation()
                    {
                        Created = date,
                        Modified = date,
                        TeamId = teamId,
                        UserId = user.UserId
                    };
                    _appDbContext.TeamAssociations.Add(association);
                    _appDbContext.Teams.First(t => t.Id == teamId).UserCount += 1;
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
