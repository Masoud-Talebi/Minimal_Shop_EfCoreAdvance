
using Minimal_Shop.Domain.Entities.Identity;

namespace Minimal_Shop.Domain.Entities.Orders
{
    public class Order : BaseEntity, IDeleted
    {
        public Decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public long UserId { get; set; }
        public bool IsDelete { get; set; }

        //Navigations
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
    public enum OrderStatus
    {
        //در انتظار پرداخت
        Pendding,

        //در حال پردازش
        Processing,

        //تایید شده
        accepting,

        //حذف شده
        canceling,
    }
}
