using _3la_Kam_backend.Models;

namespace _3la_Kam_backend.Repositoris
{
    public interface ICategoryRipo
    {
        List<Category> GetAll();
        Category GetById(int id);
        void Insert(Category category);
        void Update(int id, Category newCategory);
        void Delete(int id);
    }
}
