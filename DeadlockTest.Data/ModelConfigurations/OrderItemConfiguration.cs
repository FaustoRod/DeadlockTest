using DeadlockTest.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeadlockTest.Data.ModelConfigurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => new { x.OrderId, x.ItemId });

            builder.HasOne(x => x.Item).WithMany(i => i.OrderItems).HasForeignKey(x => x.ItemId);
            builder.HasOne(x => x.Order).WithMany(i => i.OrderItems).HasForeignKey(x => x.OrderId);

        }
    }
}
