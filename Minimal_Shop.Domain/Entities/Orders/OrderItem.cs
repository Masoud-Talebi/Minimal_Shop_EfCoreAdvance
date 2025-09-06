
namespace Minimal_Shop.Domain.Entities.Orders
{
    public class OrderItem : BaseEntity, IDeleted
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsDelete { get; set; }

        //Navigations
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
