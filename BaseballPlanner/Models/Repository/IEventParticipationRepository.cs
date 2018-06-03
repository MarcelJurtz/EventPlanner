namespace Planner.Models.Repository
{
    public interface IEventParticipationRepository : IRepository<EventParticipation>
    {
        void Update(int eventId, int userId, bool yes, bool no, string note);
    }
}
