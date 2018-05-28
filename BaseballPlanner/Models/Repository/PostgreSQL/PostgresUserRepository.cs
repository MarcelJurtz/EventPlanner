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

        public void CommitChanges()
        {
            _appDbContext.SaveChanges();
        }
    }
}
