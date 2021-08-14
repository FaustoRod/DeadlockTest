using DeadlockTest.Data.ModelConfigurations;
using DeadlockTest.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DeadlockTest.Data.Contexts
{
    public class DeadlockDbContext : DbContext
    {
        public DeadlockDbContext(DbContextOptions<DeadlockDbContext> options) : base(options)
        {
            
        }

        public DbSet<Order> Orders{ get; set; }
        public DbSet<Item> Items{ get; set; }
        public DbSet<OrderItem> OrderItems{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
        }
    }
}
