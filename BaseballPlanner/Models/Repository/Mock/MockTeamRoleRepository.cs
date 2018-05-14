using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Planner.Models.Repository.Mock
{
    public class MockTeamRoleRepository : ITeamRoleRepository
    {
        private List<TeamRole> _teamRoles;

        public MockTeamRoleRepository()
        {
            _teamRoles = new List<TeamRole>()
            {
                new TeamRole()
                {
                    Id = 0,
                    Designation = "Coach"
                },
                new TeamRole()
                {
                    Id = 1,
                    Designation = "Player"
                }
            };
        }

        public void Add(TeamRole entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<TeamRole> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeamRole> Find(Expression<Func<TeamRole, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TeamRole Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeamRole> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(TeamRole entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<TeamRole> entities)
        {
            throw new NotImplementedException();
        }
    }
}
