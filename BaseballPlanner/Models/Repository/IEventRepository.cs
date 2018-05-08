using System.Collections.Generic;

namespace Planner.Models.Repository
{
    public interface IEventRepository
    {
        void AddEvent(Event e);
        void ModifyEvent(Event e);
        void DeleteEvent(Event e);

        IEnumerable<Event> GetAllEvents();
        Event GetEventById(int id);
    }
}
