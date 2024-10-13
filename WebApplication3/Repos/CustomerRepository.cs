using Microsoft.EntityFrameworkCore;
using WebApplication3.Sales;
using WebApplication3.SalesApplication;
namespace WebApplication3.Repos
{
    public class CustomerRepository
    {
        private readonly CustomerDbContext context;
        private readonly DbSet<Customer> customers;

        public CustomerRepository(CustomerDbContext context, DbSet<Customer> customers)
        {
            this.context = context;
            customers = context.Set<Customer>();
        }

        public bool Create(Customer customer)
        {
            try
            {
                customers.Add(customer);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Customer> GetAll()
        {
            return customers.ToList();
        }
        public bool GetCustomerById(int id)
        {
            try
            {
                var customer = customers.FirstOrDefault(c => c.CustomerId == id);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(Customer customer)
        {
            try
            {
                var customerFind = customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
                customerFind.CustomerName = customer.CustomerName;
                customerFind.Email = customer.Email;
                customerFind.Phone = customer.Phone;
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var customer = customers.FirstOrDefault(c => c.CustomerId == id);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Cau 1
        public IEnumerable<Customer> GetAllCustomers()
        {
            return customers.ToList();
        }

        // Cau 8
        public Customer GetCustomerWithMostOrders()
        {
            return context.Set<Order>().GroupBy(o => o.CustomerId).OrderByDescending(g => g.Count()).Select(g => customers.Find(g.Key)).FirstOrDefault();
        }

        // Cau 10
        public int GetTotalProductsSold(int customerId)
        {
            return context.Set<OrderDetails>().Where(od => od.Order.CustomerId == customerId).Sum(od => od.Quantity);
        }
    }
}
