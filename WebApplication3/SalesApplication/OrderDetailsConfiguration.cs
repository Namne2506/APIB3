using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication3.Sales;

namespace WebApplication3.SalesApplication
{
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.HasKey(e => e.OrderDetailId);
            builder.HasOne(a => a.Product).WithMany(b => b.OrderDetails).HasForeignKey(e => e.OrderDetailId);

            builder.HasOne(b => b.Order).WithMany(c => c.OrderDetails).HasForeignKey(e => e.OrderDetailId);
        }
    }
}
