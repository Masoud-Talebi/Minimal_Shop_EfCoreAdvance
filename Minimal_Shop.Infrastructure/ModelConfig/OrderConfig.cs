using Minimal_Shop.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimal_Shop.Infrastructure.ModelConfig
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(x => x.User).WithMany(x => x.Orders).HasForeignKey(x => x.UserId);
            builder.HasMany(x => x.OrderItems).WithOne(x => x.Order);

            builder.HasQueryFilter(x => x.IsDelete == false);
            builder.Property(x => x.OrderStatus).HasConversion<string>();
        }
    }
}
