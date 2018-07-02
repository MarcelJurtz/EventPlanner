using ClubGrid.Models;
using System.Collections.Generic;

namespace Planner.Models.Repository
{
    public interface ITeamRepository : IRepository<Team>
    {
        void Remove(int id, bool commit = true);
        IEnumerable<Team> GetForUser(int userId);
    }
}
