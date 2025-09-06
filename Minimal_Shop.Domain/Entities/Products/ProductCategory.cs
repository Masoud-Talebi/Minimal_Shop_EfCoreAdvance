
namespace Minimal_Shop.Domain.Entities.Products
{
    public class ProductCategory
    {
        public long ProductId { get; set; }
        public long CategoryId { get; set; }

        //Navigations
        public Product? Product { get; set; }
        public Category? Category { get; set; }
    }
}
