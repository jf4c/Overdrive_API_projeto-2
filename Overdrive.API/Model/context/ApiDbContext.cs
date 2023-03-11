using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Overdrive.API.Model.context
{
    public class ApiDbContext : DbContext 
    {
        public DbSet<People> Peoples { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Document> Documents { get; set; }

        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>()
                .Property(p => p.Status)
                .HasConversion<int>();

            modelBuilder.Entity<Company>()
                .Property(c => c.Status)
                .HasConversion<int>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
