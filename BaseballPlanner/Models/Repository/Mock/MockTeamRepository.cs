using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Planner.Models.Repository.Mock
{
    public class MockTeamRepository : ITeamRepository
    {
        private List<Team> _teams;

        public MockTeamRepository()
        {
            _teams = new List<Team>()
            {
                new Team()
                {
                    Id = 0,
                    Designation = "Ravensburg Leprechauns"
                },
                new Team()
                {
                    Id = 1,
                    Designation = "Ulm Falcons"
                },
                new Team()
                {
                    Id = 2,
                    Designation = "Stuttgart Reds"
                }
            };
        }

        public void Add(Team entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Team> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Team> Find(Expression<Func<Team, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Team Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Team> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Team entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Team> entities)
        {
            throw new NotImplementedException();
        }
    }
}
