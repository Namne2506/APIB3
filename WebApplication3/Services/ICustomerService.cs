using WebApplication3.Sales;

namespace WebApplication3.Interface
{
    public interface ICustomerService
    {
        public bool GetAll();
        public bool Create(Customer customer);
        public bool Delete(int CustomerId);
        public bool Update(int customerId, string customerName, int phone, string email);
    }
}
