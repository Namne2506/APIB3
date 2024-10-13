using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication3.Sales;

namespace WebApplication3.SalesApplication
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.ProductId);
            builder.HasMany(a => a.OrderDetails).WithOne(e => e.Product).HasForeignKey(e => e.ProductId);
        }
    }
}
