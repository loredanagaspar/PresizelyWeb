using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresizelyWeb.Data
{
    public class Product
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; }

        [Range(0.01, 1000, ErrorMessage = "Price must be between 0.01 and 1000.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Size is required.")]
        public string Size { get; set; } // Comma-separated sizes for quick display

        public string SizeChartJson { get; set; } // JSON string for detailed size chart

        public bool IsTop { get; set; } // True if the product is a top, false if a bottom
        public string Color { get; set; }// Nullable to allow optional input

        [Range(0, int.MaxValue, ErrorMessage = "Stock must be 0 or greater.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Material is required.")]
        public string Material { get; set; } = string.Empty;
        public string? Description{ get; set; }   // Optional field

        public string? SpecialTag {  get; set; } // Optional field for tags

        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public string? ImageUrl { get; set; }


    }


}
