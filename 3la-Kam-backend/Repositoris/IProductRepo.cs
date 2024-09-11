using _3la_Kam_backend.Models;

namespace _3la_Kam_backend.Repositoris
{
    public interface IProductRepo
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Insert(Product product);
        void Update(int id, Product newProduct);
        void Delete(int id);
    }
}
