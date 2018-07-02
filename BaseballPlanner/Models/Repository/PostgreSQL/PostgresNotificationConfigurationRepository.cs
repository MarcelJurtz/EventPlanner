using ClubGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Planner.Models.Repository.PostgreSQL
{
    public class PostgresNotificationConfigurationRepository : INotificationConfigurationRepository
    {
        private readonly AppDbContext _appDbContext;

        public PostgresNotificationConfigurationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(NotificationConfiguration entity, bool commit = true)
        {
            _appDbContext.NotificationConfigurations.Add(entity);

            if (commit)
                _appDbContext.SaveChanges();
        }

        public void AddRange(IEnumerable<NotificationConfiguration> entities, bool commit = true)
        {
            _appDbContext.NotificationConfigurations.AddRange(entities);

            if (commit)
                _appDbContext.SaveChanges();
        }

        public void CommitChanges()
        {
            _appDbContext.SaveChanges();
        }

        public IEnumerable<NotificationConfiguration> Find(Expression<Func<NotificationConfiguration, bool>> predicate)
        {
            return _appDbContext.NotificationConfigurations.Where(predicate.Compile());
        }

        public NotificationConfiguration Get(int id)
        {
            return _appDbContext.NotificationConfigurations.FirstOrDefault(n => n.Id == id);
        }

        public IEnumerable<NotificationConfiguration> GetAll()
        {
            return _appDbContext.NotificationConfigurations;
        }

        public NotificationConfiguration GetConfigurationForUser(int userId)
        {
            return _appDbContext.NotificationConfigurations.FirstOrDefault(c => c.AdminId == userId);
        }

        public void Remove(NotificationConfiguration entity, bool commit = true)
        {
            _appDbContext.NotificationConfigurations.Remove(entity);

            if (commit)
                _appDbContext.SaveChanges();
        }

        public void RemoveRange(IEnumerable<NotificationConfiguration> entities, bool commit = true)
        {
            _appDbContext.NotificationConfigurations.RemoveRange(entities);

            if (commit)
                _appDbContext.SaveChanges();
        }
    }
}
