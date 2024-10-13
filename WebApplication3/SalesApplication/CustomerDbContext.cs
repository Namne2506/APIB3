using Microsoft.EntityFrameworkCore;
using WebApplication3.Sales;

namespace WebApplication3.SalesApplication
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext()
        {

        }

        public CustomerDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product>  Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Categories> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-35VIVUJ;Initial Catalog=SalesApplication;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailsConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
