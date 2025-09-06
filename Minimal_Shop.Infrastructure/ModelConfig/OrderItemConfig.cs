using Minimal_Shop.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimal_Shop.Infrastructure.ModelConfig
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasOne(x => x.Order).WithMany(x => x.OrderItems).HasForeignKey(x => x.OrderId);
            builder.HasOne(x => x.Product).WithMany(x => x.OrderItems).HasForeignKey(x => x.ProductId);

            builder.HasQueryFilter(x => x.IsDelete == false);
        }
    }
}
