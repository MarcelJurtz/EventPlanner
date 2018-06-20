namespace Planner.Notification
{
    public interface IEmail : INotification
    {
        string Subject { get; }
    }
}
