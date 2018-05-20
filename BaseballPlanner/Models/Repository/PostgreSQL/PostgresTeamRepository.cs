using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Planner.Models.Repository.PostgreSQL
{
    public class PostgresTeamRepository : ITeamRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostgresTeamRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public void Add(Team entity)
        {
            _appDbContext.Teams.Add(entity);
            _appDbContext.SaveChanges();
        }

        public void AddRange(IEnumerable<Team> entities)
        {
            _appDbContext.Teams.AddRange(entities);
            _appDbContext.SaveChanges();
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

        public void Remove(Team entity)
        {
            _appDbContext.Teams.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public void RemoveRange(IEnumerable<Team> entities)
        {
            _appDbContext.Teams.RemoveRange(entities);
            _appDbContext.SaveChanges();
        }
    }
}
