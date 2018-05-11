using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.Models.Repository.PostgreSQL
{
    public class PostgresUserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostgresUserRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public void AddUser(User user)
        {
            _appDbContext.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            _appDbContext.Users.Remove(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _appDbContext.Users;
        }

        public User GetUserById(int id)
        {
            return _appDbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public void ModifyUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
