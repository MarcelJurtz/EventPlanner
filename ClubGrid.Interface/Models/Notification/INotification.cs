namespace ClubGrid.Models
{
    public interface INotification
    {
        string Recipient { get; }
        string Content { get; }

        void Send();
    }
}
