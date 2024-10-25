using WebApplication3.Sales;

namespace WebApplication3.Services
{
    public interface IProductService
    {
        public bool GetAll();
        public bool Create(Product product);
        public bool Update(int ProductId, string ProductName, Decimal Price, int Stock);
        public bool Delete(int ProductId);
    }
}
