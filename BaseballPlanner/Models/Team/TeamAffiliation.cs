namespace Planner.Models
{
    public class TeamAffiliation
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Team Team { get; set; }
        public TeamRole Role { get; set; }
    }
}
