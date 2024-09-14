using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _3la_Kam_backend.Models
{
    public class context : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public context() { }
        public context(DbContextOptions<context> options) : base(options) { }

        
    }
}
