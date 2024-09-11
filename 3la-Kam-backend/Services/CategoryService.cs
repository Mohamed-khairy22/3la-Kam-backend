using _3la_Kam_backend.Models;
using _3la_Kam_backend.Repositoris;

namespace _3la_Kam_backend.Services
{
    public class CategoryService : ICategoryRipo
    {
        context context;
        public CategoryService(context context)
        {
            this.context = context;
        }
        public List<Category> GetAll()
        {
            return context.categories.ToList();
        }
        public Category GetById(int id)
        {
            return context.categories.FirstOrDefault(i => i.Id == id);
        }
        public void Insert(Category Category)
        {
            context.categories.Add(Category);
            context.SaveChanges();
        }
        public void Update(int id, Category newCategory)
        {
            Category oldCategory = GetById(id);
            oldCategory.Name = newCategory.Name;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            context.categories.Remove(GetById(id));
            context.SaveChanges();
        }
    }
}
