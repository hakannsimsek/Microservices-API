using Microsoft.EntityFrameworkCore;
using SecondService.Models;

namespace SecondService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Platform> Platforms{ get; set; }
        public DbSet<Second> Seconds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Platform>()
                .HasMany(p => p.Seconds)
                .WithOne(p => p.Platform!)
                .HasForeignKey(p => p.PlatformId);

            modelBuilder
                .Entity<Second>()
                .HasOne(p => p.Platform)
                .WithMany(p => p.Seconds!)
                .HasForeignKey(p => p.PlatformId);

        }
    }
}
