using ClubGrid.Models;
using ClubGrid.ViewModels;

namespace ClubGrid.Repository
{
    public interface IEventParticipationRepository : IRepository<EventParticipation>
    {
        void Update(int eventId, int userId, EventParticipateViewModel viewModel);
    }
}
