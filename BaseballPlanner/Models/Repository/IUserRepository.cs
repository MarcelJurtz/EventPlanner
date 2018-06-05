using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Planner.Models.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        IEnumerable<User> Find(Expression<Func<User, bool>> predicate);
        User FindUserByUserId(int userId);
        String GetUsernameByUserId(int userId);
        void CommitChanges();
    }
}
