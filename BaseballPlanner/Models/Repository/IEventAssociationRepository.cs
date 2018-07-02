using ClubGrid.Models;
using ClubGrid.Repository;
using System.Collections.Generic;

namespace Planner.Models.Repository
{
    public interface IEventAssociationRepository : IRepository<EventAssociation>
    {
        void Update(int eventId, IEnumerable<Team> teams);
    }
}
