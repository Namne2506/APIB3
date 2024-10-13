using Microsoft.EntityFrameworkCore;
using WebApplication3.Sales;
using WebApplication3.SalesApplication;

namespace WebApplication3.Repos
{
    public class OrderRepository
    {
        private readonly CustomerDbContext context;
        private readonly DbSet<Order> orders;

        public OrderRepository(CustomerDbContext context, DbSet<Order> orders)
        {
            this.context = context;
            this.orders = orders;
        }


        public bool Create(Order order)
        {
            try
            {
                context.Add(order);
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Order> GetAll()
        {
            return orders.ToList();
        }
        public bool GetOrderById(int id)
        {
            try
            {
                var OrderFind = orders.FirstOrDefault(c => c.CustomerId == id);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(Order order)
        {
            try
            {
                var OrderFind = orders.FirstOrDefault(c => c.OrderId == order.OrderId);
                OrderFind.OrderDate = order.OrderDate;
                OrderFind.CustomerId = order.CustomerId;
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
                var OrderFind = orders.FirstOrDefault(c => c.OrderId == id);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //Cau 3
        public IEnumerable<Order> GetByCustomerId(int customerId)
        {
            return orders.Where(o => o.CustomerId == customerId).Include(o => o.OrderDetails).ToList();
        }

        // Cau 4
        public Order GetById(int Id)
        {
            return orders.Include(o => o.OrderDetails).FirstOrDefault(o => o.OrderId == Id);
        }

    }
}
