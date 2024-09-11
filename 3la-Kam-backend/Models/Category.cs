using System.Text.Json.Serialization;

namespace _3la_Kam_backend.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual List<Product>? Product { get; set; }

    }
}
