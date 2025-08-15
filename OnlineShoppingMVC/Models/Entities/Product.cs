using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingMVC.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required, MaxLength(120)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Range(0.01, 9999999)]
        public decimal Price { get; set; }

        [Range(0, 100)]
        public decimal DiscountPercent { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
