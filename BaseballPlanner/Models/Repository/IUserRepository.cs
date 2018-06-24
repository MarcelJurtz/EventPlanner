using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Planner.Models.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        IEnumerable<User> Find(Expression<Func<User, bool>> predicate);
        Task<IEnumerable<User>> GetUsersInRole(string roleName);
        User FindUserByUserId(int userId);
        String GetUsernameByUserId(int userId);
        void CommitChanges();
    }
}
