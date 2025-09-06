
namespace Minimal_Shop.Domain.Entities.Products
{
    public class Category : BaseEntity
    {
        public required string Title { get; set; }

        public long? ParentId { get; set; }
        //Navigations
        public virtual Category? ParentCategory { get; set; }
        public virtual ICollection<Category>? ChildrenCategories { get; set; }
        public virtual ICollection<ProductCategory>? ProductCategories { get; set; }
    }
}
