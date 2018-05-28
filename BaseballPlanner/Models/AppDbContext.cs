using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Planner.Models
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventAssociation> EventAssociations { get; set; }
        public DbSet<EventParticipation> EventParticipations { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamAssociation> TeamAssociations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Team>()
                .HasIndex(t => t.Designation)
                .IsUnique();

            builder.Entity<TeamAssociation>()
                .HasIndex(t => new { t.UserId, t.TeamId, t.Role })
                .IsUnique();

            builder.Entity<EventAssociation>()
                .HasIndex(e => new { e.TeamId, e.EventId })
                .IsUnique();

            base.OnModelCreating(builder);
        }
    }
}
