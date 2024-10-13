using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication3.Sales;

namespace WebApplication3.SalesApplication
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c =>  c.CustomerId);
            builder.HasMany(c => c.Orders).WithOne(c => c.Customer).HasForeignKey(o => o.CustomerId);
        }
    }
}
