using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Sales;
using WebApplication3.SalesApplication;

namespace WebApplication3.Repos
{
    public class ProductRepository
    {
        private readonly CustomerDbContext context;
        private readonly DbSet<Product> products;

        public ProductRepository(CustomerDbContext context)
        {
            this.context = context;
            products = context.Set<Product>();
        }

        public bool create(Product product)
        {
            try
            {
                products.Add(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Product> GetAll()
        {
            return products.ToList();
        }
        public bool GetProductById(int Id)
        {
            try
            {
                var ProductFind = products.FirstOrDefault(p => p.ProductId == Id);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(Product product)
        {
            try
            {
                var productFind = products.FirstOrDefault(p => p.ProductId == product.ProductId);
                productFind.ProductName = product.ProductName;
                productFind.Price = product.Price;
                productFind.Stock = product.Stock;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int Id)
        {
            try
            {
                var productFind = products.FirstOrDefault(p => p.ProductId == Id);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        // Cau 2
        public IEnumerable<Product> GetInStockProducts()
        {
            return products.Where(p => p.Stock > 0).ToList();
        }


        //Cau 6
        public Product GetBestSellingProduct()
        {
            var bestSellingProductId = context.Set<OrderDetails>()
                .GroupBy(od => od.ProductId)
                .OrderByDescending(g => g.Sum(od => od.Quantity))
                .Select(g => g.Key)
                .FirstOrDefault();

            return bestSellingProductId != 0 ? products.Find(bestSellingProductId) : null;
        }

        //Cau 7
        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            var category = context.Set<Categories>().Find(categoryId);
            if (category == null)
            {
                return new List<Product>();
            }

            return products.ToList();
        }

    }
}
