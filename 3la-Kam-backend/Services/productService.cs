using _3la_Kam_backend.Models;
using _3la_Kam_backend.Repositoris;

namespace _3la_Kam_backend.Services
{
    public class productService : IProductRepo
    {
        context context;
        public productService(context context)
        {
            this.context = context;
        }
        public List<Product> GetAll()
        {
            return context.products.ToList();
        }
        public List<Product> GetByCatId(int catId)
        {
            return context.products.Where(c=>c.CategoryId==catId).ToList();
        }
        public Product GetById(int id)
        {
            return context.products.FirstOrDefault(i => i.Id == id);
        }
        public List<Product> GetByName(string name, int catId)
        {
            if(name.Length==0)
                return context.products.ToList();
            if (catId == 0)
            {
                return context.products.Where(c => c.Name.ToLower().StartsWith(name.ToLower())).ToList();
            }
            return context.products.Where(c => c.CategoryId == catId).Where(c => c.Name.ToLower().StartsWith(name.ToLower())).ToList();
        }

        public void Insert(Product product)
        {
            context.products.Add(product);
            context.SaveChanges();
        }
        public void Update(int id, Product newProduct)
        {
            Product oldProduct = GetById(id);
            oldProduct.Name = newProduct.Name;
            oldProduct.imgUrl = newProduct.imgUrl;
            oldProduct.Price = newProduct.Price;
            oldProduct.Quantity = newProduct.Quantity;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            context.products.Remove(GetById(id));
            context.SaveChanges();
        }
    }
}
