using Microsoft.EntityFrameworkCore;

namespace AcademySample.Models
{
    public class ComputerDbContext : DbContext
    {
        public DbSet<ComputerDetails> ComputerDetails { get; set; }

        public ComputerDbContext(DbContextOptions<ComputerDbContext> options) : 
            base(options)
        {
            
        }
    }
}