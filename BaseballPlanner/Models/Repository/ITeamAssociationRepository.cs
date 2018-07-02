using ClubGrid.Models;
using System.Collections.Generic;

namespace ClubGrid.Repository
{
    public interface ITeamAssociationRepository : IRepository<TeamAssociation>
    {
        void Update(int userId, IEnumerable<Team> teams);
    }
}
