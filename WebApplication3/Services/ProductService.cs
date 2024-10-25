using WebApplication3.Sales;

namespace WebApplication3.Services
{
    public class ProductService : IProductService
    {
        public List<Product> Products = new List<Product>();

        public bool Create(Product product)
        {
            Products.Add(product);
            return true;
        }

        public bool Delete(int ProductId)
        {
            var productFind = Products.FirstOrDefault(p => p.ProductId == ProductId);
            Products.Remove(productFind);
            return true;
        }

        public bool GetAll()
        {
            return Products.ToList().Count > 0;
        }

        public bool Update(int ProductId, string ProductName, decimal Price, int Stock)
        {
            var productFind = Products.FirstOrDefault(p => p.ProductId == ProductId);
            productFind.ProductName = ProductName;
            productFind.Price = Price;
            productFind.Stock = Stock;
            return true;
        }
    }
}
