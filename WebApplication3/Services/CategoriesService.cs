using WebApplication3.Sales;

namespace WebApplication3.Services
{
    public class CategoriesService : ICategoriesService
    {
        public List<Categories> Categories = new List<Categories>();
        public bool Create(Categories categories)
        {
            Categories.Add(categories);
            return true;
        }

        public bool Delete(int CategoryId)
        {
            var categoryFind = Categories.FirstOrDefault(c => c.CategoryId == CategoryId);
            Categories.Remove(categoryFind);
            return true;
        }

        public bool GetAll()
        {
            return Categories.ToList().Count > 0;
        }

        public bool Update(int CategoryId, string CategoryName)
        {
            var CategoryFind = Categories.FirstOrDefault(c => c.CategoryId == CategoryId);
            CategoryFind.CategoryName = CategoryName;
            return true;
        }
    }
}
