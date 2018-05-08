using System.Collections.Generic;

namespace Planner.Models.Repository
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void ModifyUser(User user);
        void DeleteUser(User user);

        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
    }
}
