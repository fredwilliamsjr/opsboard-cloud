using Microsoft.EntityFrameworkCore;
using OpsBoard.Api.Entities;

namespace OpsBoard.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ServiceItem> Services => Set<ServiceItem>();
        public DbSet<Incident> Incidents => Set<Incident>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incident>()
                .HasOne(i => i.ServiceItem)
                .WithMany()
                .HasForeignKey(i => i.ServiceItemId);

            base.OnModelCreating(modelBuilder); // good practice
        }
    }
}