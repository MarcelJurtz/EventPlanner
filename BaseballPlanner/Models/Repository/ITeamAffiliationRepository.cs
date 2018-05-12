using System.Collections.Generic;

namespace Planner.Models.Repository
{
    interface ITeamAffiliationRepository
    {
        IEnumerable<TeamAffiliation> TeamAffiliations { get; }
        void AddTeamAffiliation(TeamAffiliation teamAffiliation);
        void RemoveTeamAffiliation(TeamAffiliation teamAffiliation);
    }
}
