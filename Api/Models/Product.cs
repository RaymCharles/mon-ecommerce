using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
