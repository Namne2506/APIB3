using WebApplication3.Sales;

namespace WebApplication3.Services
{
    public interface ICategoriesService
    {
        public bool GetAll();
        public bool Create(Categories categories);
        public bool Update(int CategoryId, string CategoryName);
        public bool Delete(int CategoryId);
    }
}
