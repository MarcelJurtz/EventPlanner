using Planner.ViewModels;

namespace Planner.Models.Repository
{
    public interface IEventParticipationRepository : IRepository<EventParticipation>
    {
        void Update(int eventId, int userId, EventParticipateViewModel viewModel);
    }
}
