using System.Collections.Generic;

namespace Planner.Models.Repository
{
    public interface ITeamRepository
    {
        IEnumerable<Team> Teams { get; }
        void AddTeam(Team team);
        void ModifyTeam(Team team);
        void DeleteTeam(Team team);
    }
}
