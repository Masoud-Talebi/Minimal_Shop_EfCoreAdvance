using Minimal_Shop.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimal_Shop.Infrastructure.ModelConfig
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> b)
        {
            b.HasQueryFilter(x => x.IsDelete == false);
            b.HasIndex(p => p.Title).HasFilter("[IsDelete] = 0");
        }
    }
}
