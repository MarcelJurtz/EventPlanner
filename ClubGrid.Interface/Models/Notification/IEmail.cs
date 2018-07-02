namespace ClubGrid.Models
{
    public interface IEmail : INotification
    {
        string Subject { get; }
    }
}
