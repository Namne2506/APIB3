using Microsoft.EntityFrameworkCore;
using WebApplication3.Sales;
using WebApplication3.SalesApplication;

namespace WebApplication3.Repos
{
    public class OrderDetailsRepository
    {
        private readonly CustomerDbContext context;
        private readonly DbSet<OrderDetails> orderDetailsD;

        public OrderDetailsRepository(CustomerDbContext context, DbSet<OrderDetails> orderDetails)
        {
            this.context = context;
            orderDetailsD = orderDetails;
        }

        public bool create(OrderDetails orderDetails)
        {
            try
            {
                context.Add(orderDetails);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public List<OrderDetails> GetAll()
        {
            return orderDetailsD.ToList();
        }
        public bool GetOrderDetailsById(int id)
        {
            try
            {
                var AorderDetails = orderDetailsD.FirstOrDefault(c => c.OrderDetailId == id);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(OrderDetails orderDetails)
        {
            try
            {
                var AorderDetails = orderDetailsD.FirstOrDefault(o => o.OrderDetailId == orderDetails.OrderDetailId);
                AorderDetails.OrderId = orderDetails.OrderId;
                AorderDetails.ProductId = orderDetails.ProductId;
                AorderDetails.Quantity = orderDetails.Quantity;
                AorderDetails.UnitPrice = orderDetails.UnitPrice;
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
                var AorderDetails = orderDetailsD.FirstOrDefault(o => o.OrderDetailId == id);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        // cau 5
        public decimal GetTotalRevenue()
        {
            return orderDetailsD.Sum(od => od.Quantity * od.UnitPrice);
        }



    }
}
