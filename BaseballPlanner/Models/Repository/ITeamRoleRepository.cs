using System.Collections.Generic;

namespace Planner.Models.Repository
{
    public interface ITeamRoleRepository
    {
        void AddRole(TeamRole role);
        void ModifyRole(TeamRole role);
        void DeleteRole(TeamRole role);

        IEnumerable<TeamRole> TeamRoles { get; }
    }
}
