using System.Collections.Generic;

namespace Planner.Models.Repository
{
    public interface IEventRoleRepository
    {
        void AddEventRole(EventRole role);
        void ModifyEventRole(EventRole role);
        void DeleteEventRole(EventRole role);

        IEnumerable<EventRole> GetAllEventRoles();
    }
}
