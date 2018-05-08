using System;
using System.Collections.Generic;

namespace Planner.Models.Repository.Mock
{
    public class MockUserRepository : IUserRepository
    {
        private List<User> _users;

        public MockUserRepository()
        {
            _users = new List<User>()
            {
                new Administrator()
                {
                    Id = 0,
                    EMail = "marcel@planner.com",
                    Username = "Marcel"
                },
                new Member()
                {
                    Id = 1,
                    EMail = "test@planner.com",
                    Username = "TestAccount"
                }
            };
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void ModifyUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
