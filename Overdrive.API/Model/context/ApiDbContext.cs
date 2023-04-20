using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Overdrive.API.Model.context
{
    public class ApiDbContext : DbContext 
    {
        public ApiDbContext(DbContextOptions options) : base(options) { }

        public DbSet<People> Peoples { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>()
                .Property(p => p.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Company>()
                .Property(c => c.Status)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
