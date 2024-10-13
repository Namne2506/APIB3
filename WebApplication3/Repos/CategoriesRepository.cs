using Microsoft.EntityFrameworkCore;
using WebApplication3.Sales;
using WebApplication3.SalesApplication;

namespace WebApplication3.Repos
{
    public class CategoriesRepository
    {
        private readonly CustomerDbContext context;
        private readonly DbSet<Categories> category;

        public CategoriesRepository(CustomerDbContext context, DbSet<Categories> categories)
        {
            this.context = context;
            category = categories;
        }
        public bool create(Categories categories)
        {
            try
            {
                context.Add(categories);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public List<Categories> GetAll()
        {
            return category.ToList();
        }
        public bool GetCategoriesById(int id)
        {
            try
            {
                var Vcategories = category.FirstOrDefault(c => c.CategoryId == id);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(Categories categories)
        {
            try
            {
                var Vcategories = category.FirstOrDefault(c => c.CategoryId == categories.CategoryId);
                Vcategories.CategoryId = categories.CategoryId;
                Vcategories.CategoryName = categories.CategoryName;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var Vcategories = category.FirstOrDefault(c => c.CategoryId == id);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }

}
