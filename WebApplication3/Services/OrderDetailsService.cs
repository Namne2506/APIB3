using WebApplication3.Sales;

namespace WebApplication3.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        public List<OrderDetails> OrderDetails = new List<OrderDetails>();
        public bool Create(OrderDetails orderDetails)
        {
            OrderDetails.Add(orderDetails);
            return true;
        }

        public bool Delete(int OrderDetailId)
        {
            var OrderDetailsFind = OrderDetails.FirstOrDefault(o => o.OrderDetailId == OrderDetailId);
            OrderDetails.Remove(OrderDetailsFind);
            return true;
        }

        public bool GetAll()
        {
            return OrderDetails.ToList().Count > 0;
        }

        public bool Update(int OrderDetailId, int OrderId, int ProductId, int Quantity, decimal UnitPrice)
        {
           var OrderDetailsFind = OrderDetails.FirstOrDefault(o => o.OrderDetailId == OrderDetailId);
            OrderDetailsFind.OrderId = OrderId;
            OrderDetailsFind.ProductId = ProductId;
            OrderDetailsFind.Quantity = Quantity;
            OrderDetailsFind.UnitPrice = UnitPrice;

            return true;

        }
    }
}
