using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public void AddRole(TeamRole role)
        {
            _teamRoles.Add(role);
        }

        public void DeleteRole(TeamRole role)
        {
            _teamRoles.Remove(role);
        }

        public IEnumerable<TeamRole> GetAllTeamRoles()
        {
            return _teamRoles;
        }

        public void ModifyRole(TeamRole role)
        {
            var item = _teamRoles.FirstOrDefault(x => x.Id == role.Id);
            item = role;
        }
    }
}
