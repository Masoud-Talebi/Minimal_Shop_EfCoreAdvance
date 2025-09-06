
namespace Minimal_Shop.Domain.Entities.Products
{
    public class Product : BaseEntity, IDeleted
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required decimal Price { get; set; }
        public int? Count { get; set; }
        public byte[]? Image { get; set; }

        //Navigations
        public ICollection<ProductCategory>? ProductCategories { get; set; }
        public ICollection<OrderItem>? OrderItems{ get; set; }
        public bool IsDelete { get; set; }
    }
}
