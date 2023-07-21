using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace LoseSumWeight.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? ImagePath { get; set; }
        public int ? LeftInStock { get; set; }
        public bool IsFavorite { get; set; }


    }
}
