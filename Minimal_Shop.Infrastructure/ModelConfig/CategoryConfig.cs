using Minimal_Shop.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimal_Shop.Infrastructure.ModelConfig
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(p => p.ChildrenCategories).WithOne(x => x.ParentCategory).HasForeignKey(x => x.ParentId);
        }
    }
}
