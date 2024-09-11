using _3la_Kam_backend.Models;

namespace _3la_Kam_backend.Services
{
    public class productService
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
        public Product GetById(int id)
        {
            return context.products.FirstOrDefault(i => i.Id == id);
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
