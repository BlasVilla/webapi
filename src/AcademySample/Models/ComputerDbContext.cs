using Microsoft.EntityFrameworkCore;

namespace AcademySample.Models
{
    public class ComputerDbContext : DbContext
    {
        public DbSet<ComputerDetails> ComputerDetails { get; set; }

        public DbSet<UsageData> UsageData { get; set; }

        public ComputerDbContext(DbContextOptions<ComputerDbContext> options) : 
            base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsageData>()
                .HasOne(u => u.ComputerDetails)
                .WithMany(cd => cd.UsageData)
                .HasForeignKey(u => u.ComputerName);
        }
    }
}