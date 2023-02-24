using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shop.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        [Required]
        public string Serial { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]
        public virtual Category? Category { get; set; }

    }
}
