using Microsoft.EntityFrameworkCore;

namespace Planner.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventRole> EventRoles { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamAffiliation> TeamAffiliations { get; set; }
        public DbSet<TeamRole> TeamRoles { get; set; }
        public DbSet<User> Users { get; set; }
}
}
