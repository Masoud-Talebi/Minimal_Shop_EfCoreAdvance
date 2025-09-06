
namespace Minimal_Shop.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser<long>, IDeleted
    {
        [Required]
        [MaxLength(150)]
        public required string FirstName { get; set; }
        [Required]
        [MaxLength(150)]
        public required string LastName { get; set; }
        public bool IsDelete { get; set; }


        public virtual ICollection<Order> Orders { get; set; }
    }
}
