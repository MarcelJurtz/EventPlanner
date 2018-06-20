namespace Planner.Notification
{
    public interface INotification
    {
        string Recipient { get; }
        string Content { get; }

        void Send();
    }
}
