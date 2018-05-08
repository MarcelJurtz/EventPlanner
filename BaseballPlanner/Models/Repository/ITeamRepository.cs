namespace Planner.Models.Repository
{
    public interface ITeamRepository
    {
        void AddTeam(Team team);
        void ModifyTeam(Team team);
        void DeleteTeam(Team team);
    }
}
