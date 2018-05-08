namespace Planner.Models
{
    /// <summary>
    /// Defines a specific persons role in a team
    /// eg. player, coach
    /// </summary>
    public class TeamRole
    {
        public int Id { get; set; }
        public string Designation { get; set; }
    }
}
