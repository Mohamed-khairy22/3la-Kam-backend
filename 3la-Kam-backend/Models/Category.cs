namespace _3la_Kam_backend.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<product>? Product { get; set; }

    }
}
