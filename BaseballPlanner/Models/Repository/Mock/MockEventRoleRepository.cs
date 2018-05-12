using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Models.Repository.Mock
{
    public class MockEventRoleRepository : IEventRoleRepository
    {
        private List<EventRole> _eventRoles;

        public MockEventRoleRepository()
        {
            _eventRoles = new List<EventRole>()
            {
                new EventRole()
                {
                    Id = 0,
                    Designation = "Player",
                    QuantityRequired = null
                },
                new EventRole()
                {
                    Id = 1,
                    Designation = "Coach",
                    QuantityRequired = 2
                },
                new EventRole()
                {
                    Id = 2,
                    Designation = "Driver",
                    QuantityRequired = null,
                    SubDesignation = "Seats",
                    SubQuantityRequired = 15
                },
                new EventRole()
                {
                    Id = 3,
                    Designation = "Umpire",
                    QuantityRequired = 2
                },
                new EventRole()
                {
                    Id = 4,
                    Designation = "Scorer",
                    QuantityRequired = 2
                }
            };
        }


        public void AddEventRole(EventRole role)
        {
            _eventRoles.Add(role);
        }

        public void DeleteEventRole(EventRole role)
        {
            _eventRoles.Remove(role);
        }

        public IEnumerable<EventRole> EventRoles
        {
            get { return _eventRoles; }
        }

        public void ModifyEventRole(EventRole role)
        {
            var item = _eventRoles.FirstOrDefault(x => x.Id == role.Id);
            item = role;
        }
    }
}
