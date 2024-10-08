﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace _3la_Kam_backend.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity {  get; set; }  
        public string imgUrl { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public virtual Category? Category { get; set; }

    }
}
