using ClubGrid.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Planner.Models.Repository.PostgreSQL
{
    public class PostgresUserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<User> _userManager;

        public PostgresUserRepository(AppDbContext context, UserManager<User> userManager)
        {
            _appDbContext = context;
            _userManager = userManager;
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            return _appDbContext.Users.Where(predicate.Compile()).ToList();
        }

        public IEnumerable<User> GetAll()
        {
            return _appDbContext.Users;
        }

        public async Task<IEnumerable<User>> GetUsersInRole(string roleName)
        {
            //var role = _appDbContext.Roles.SingleOrDefault(m => m.Name == roleName);
            return await _userManager.GetUsersInRoleAsync(roleName);
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
