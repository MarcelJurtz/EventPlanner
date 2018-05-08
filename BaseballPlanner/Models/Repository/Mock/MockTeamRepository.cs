using System.Collections.Generic;
using System.Linq;

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

        public void AddTeam(Team team)
        {
            _teams.Add(team);
        }

        public void DeleteTeam(Team team)
        {
            _teams.Remove(team);
        }

        public void ModifyTeam(Team team)
        {
            var item = _teams.FirstOrDefault(x => x.Id == team.Id);
            item = team;
        }
    }
}
