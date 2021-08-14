using DeadlockTest.Data.ModelConfigurations;
using Microsoft.EntityFrameworkCore;

namespace DeadlockTest.Data.Contexts
{
    public class DeadlockDbContext : DbContext
    {
        public DeadlockDbContext(DbContextOptions<DeadlockDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
        }
    }
}
