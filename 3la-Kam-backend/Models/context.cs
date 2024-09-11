using Microsoft.EntityFrameworkCore;

namespace _3la_Kam_backend.Models
{
    public class context:DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public context() { }
        public context(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-FMRLOB8\\MSSQLSERVER1;Initial Catalog=3laKam;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
