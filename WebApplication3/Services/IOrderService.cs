using WebApplication3.Sales;

namespace WebApplication3.Services
{
    public interface IOrderService
    {
        public bool GetAll();
        public bool Create(Order order);
        public bool Update(int OrderId, DateTime OrderDate, int CustomerId);
        public bool Delete(int OrderId);
    }
}
