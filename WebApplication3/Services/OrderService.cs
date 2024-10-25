using WebApplication3.Sales;

namespace WebApplication3.Services
{
    public class OrderService : IOrderService
    {
        public List<Order> Orders = new List<Order>();
        public bool Create(Order order)
        {
            Orders.Add(order);
            return true;
        }

        public bool Delete(int OrderId)
        {
           var OrderFind = Orders.FirstOrDefault(o => o.OrderId == OrderId);
            Orders.Remove(OrderFind);
            return true;
        }

        public bool GetAll()
        {
            return Orders.ToList().Count > 0;
        }

        public bool Update(int OrderId, DateTime OrderDate, int CustomerId)
        {
            var OrderFind = Orders.FirstOrDefault(o => o.OrderId ==OrderId);
            OrderFind.OrderDate = OrderDate;
            OrderFind.CustomerId = CustomerId;
            return true;
        }
    }
}
