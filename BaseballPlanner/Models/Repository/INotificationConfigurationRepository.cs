using ClubGrid.Models;

namespace ClubGrid.Repository
{
    public interface INotificationConfigurationRepository : IRepository<NotificationConfiguration>
    {
        NotificationConfiguration GetConfigurationForUser(int userId);
    }
}
