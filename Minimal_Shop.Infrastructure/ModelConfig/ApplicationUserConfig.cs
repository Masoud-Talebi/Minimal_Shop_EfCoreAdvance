

using Microsoft.EntityFrameworkCore;

namespace Minimal_Shop.Infrastructure.ModelConfig
{
    public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> b)
        {

            b.HasQueryFilter(x => x.IsDelete == false);
            b.HasIndex(p => p.UserName).IsUnique().HasFilter("[IsDelete] = 0");
        }
    }
}
