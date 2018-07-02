using ClubGrid.Models;

namespace Planner.Models.Repository
{
    public interface INotificationConfigurationRepository : IRepository<NotificationConfiguration>
    {
        NotificationConfiguration GetConfigurationForUser(int userId);
    }
}
