using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication3.Sales;

namespace WebApplication3.SalesApplication
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.OrderId);
            builder.HasMany(a => a.OrderDetails).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);

            builder.HasOne(c => c.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId);
             
        }
    }
}
