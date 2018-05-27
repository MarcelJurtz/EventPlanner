namespace Planner.Models.Repository
{
    public interface ITeamRepository : IRepository<Team>
    {
        void Remove(int id, bool commit = true);
    }
}
