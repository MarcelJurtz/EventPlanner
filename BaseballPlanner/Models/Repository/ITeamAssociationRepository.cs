using System.Collections.Generic;

namespace Planner.Models.Repository
{
    public interface ITeamAssociationRepository : IRepository<TeamAssociation>
    {
        void Update(int userId, IEnumerable<Team> teams);
    }
}
