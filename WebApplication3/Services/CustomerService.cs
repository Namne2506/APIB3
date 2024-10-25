using WebApplication3.Interface;
using WebApplication3.Sales;

namespace WebApplication3.Services
{
    public class CustomerService : ICustomerService
    {
        public List<Customer> customers =   new List<Customer>();

        public bool Create(Customer customer)
        {
            customers.Add(customer);
            return true;
        }

        public bool Delete(int CustomerId)
        {
            var customerFind = customers.FirstOrDefault(c => c.CustomerId == CustomerId);
            customers.Remove(customerFind);
            return true;
        }

        public bool GetAll()
        {
            return customers.ToList().Count > 0;
        }

        public bool Update(int customerId, string customerName, int phone, string email)
        {
            var customerFind = customers.FirstOrDefault(c => c.CustomerId == customerId);
            customerFind.CustomerName = customerName;
            customerFind.Phone = phone;
            customerFind.Email = email;
            return true;
        }
    }
}
