using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Planner.Models.Repository.PostgreSQL
{
    public class PostgresUserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostgresUserRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            return _appDbContext.Users.Where(predicate.Compile()).ToList();
        }

        public IEnumerable<User> GetAll()
        {
            return _appDbContext.Users;
        }

        public User FindUserByUserId(int userId)
        {
            return _appDbContext.Users.Where(x => x.UserId == userId).FirstOrDefault();
        }

        public String GetUsernameByUserId(int userId)
        {
            var user = FindUserByUserId(userId);
            return user == null ? "Not Found" : user.UserName;
        }

        public void CommitChanges()
        {
            _appDbContext.SaveChanges();
        }
    }
}
