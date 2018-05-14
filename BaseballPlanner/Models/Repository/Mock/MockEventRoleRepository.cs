using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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

        public void Add(EventRole entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<EventRole> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventRole> Find(Expression<Func<EventRole, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public EventRole Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventRole> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(EventRole entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<EventRole> entities)
        {
            throw new NotImplementedException();
        }
    }
}
