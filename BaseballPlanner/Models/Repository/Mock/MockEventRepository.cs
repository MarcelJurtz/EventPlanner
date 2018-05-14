using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Planner.Models.Repository.Mock
{
    public class MockEventRepository : IEventRepository
    {
        private List<Event> _events;

        public MockEventRepository()
        {
            Administrator creator = new Administrator() { Username = "Marcel", EMail = "marcel@planner.com", Id = 0 };

            _events = new List<Event>() {
                new Event()
                {
                    Id = 0,
                    Created = new DateTime(2018, 05, 01, 10, 30, 00),
                    Modified = new DateTime(2018, 05, 02, 21, 07, 00),
                    CreatedBy = creator,
                    Description = "Freundschaftsspiel Ravensburg vs. Ulm",
                    Designation = "Ravensburg vs. Ulm",
                    Start = new DateTime(2018, 06, 01, 15, 00, 00),
                    End = new DateTime(2018, 06, 01, 18, 00, 00),
                    Location = "Ravensburg",
                    MeetingLocation = "Lager, TSB",
                    MeetingTime = new DateTime(2018, 06, 01, 12, 30, 00),
                    ModifiedBy = creator,
                    Teams = null
                }
           };
        }

        public void Add(Event entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Event> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> Find(Expression<Func<Event, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Event Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Event entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Event> entities)
        {
            throw new NotImplementedException();
        }
    }
}
