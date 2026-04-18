using Microsoft.EntityFrameworkCore;
using OpsBoard.Api.Entities;

namespace OpsBoard.Api.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<ServiceItem> Services => Set<ServiceItem>();
    }
}
