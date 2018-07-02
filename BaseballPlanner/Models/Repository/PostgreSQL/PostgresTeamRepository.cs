using ClubGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ClubGrid.Repository.PostgreSQL
{
    public class PostgresTeamRepository : ITeamRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostgresTeamRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public void Add(Team entity, bool commit = true)
        {
            _appDbContext.Teams.Add(entity);

            if (commit)
                CommitChanges();
        }

        public void AddRange(IEnumerable<Team> entities, bool commit = true)
        {
            _appDbContext.Teams.AddRange(entities);

            if (commit)
                CommitChanges();
        }

        public IEnumerable<Team> Find(Expression<Func<Team, bool>> predicate)
        {
            return _appDbContext.Teams.Where(predicate.Compile()).ToList();
        }

        public Team Get(int id)
        {
            return _appDbContext.Teams.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Team> GetAll()
        {
            return _appDbContext.Teams;
        }

        public void Remove(int id, bool commit = true)
        {
            _appDbContext.Teams.Remove(_appDbContext.Teams.First(x => x.Id == id));

            if (commit)
                CommitChanges();
        }

        public void Remove(Team entity, bool commit = true)
        {
            _appDbContext.Teams.Remove(entity);

            if (commit)
                CommitChanges();
        }

        public void RemoveRange(IEnumerable<Team> entities, bool commit = true)
        {
            _appDbContext.Teams.RemoveRange(entities);

            if (commit)
                CommitChanges();
        }

        public IEnumerable<Team> GetForUser(int userId)
        {
            var teamIds = _appDbContext.TeamAssociations.Where(x => x.UserId == userId).Select(x => x.TeamId);
            return _appDbContext.Teams.Where(t => teamIds.Contains(t.Id));
        }

        public void CommitChanges()
        {
            _appDbContext.SaveChanges();
        }
    }
}
