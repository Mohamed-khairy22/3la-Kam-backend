using Microsoft.EntityFrameworkCore;

namespace _3la_Kam_backend.Models
{
    public class context : DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public context() { }
        public context(DbContextOptions<context> options) : base(options) { }

        
    }
}
