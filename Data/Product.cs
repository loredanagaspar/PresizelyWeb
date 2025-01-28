using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresizelyWeb.Data
{
    // Represents the Product entity, which maps to a table in the database.
    // This model is used to define the structure and properties of products in the e-commerce platform.
    public class Product
    {
        // Primary Key for the Product table.
        public int Id { get; set; }

        // Product name is required and validated using data annotations to ensure input.
        [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; }

        // Product price with validation to ensure it falls between 0.01 and 1000.
        [Range(0.01, 1000, ErrorMessage = "Price must be between 0.01 and 1000.")]
        public decimal Price { get; set; }

        // The size of the product, stored as a comma-separated string for quick display.
        // This is a required field.
        [Required(ErrorMessage = "Size is required.")]
        public string Size { get; set; }

        // Stores a detailed size chart in JSON format for advanced size matching functionality.
        public string SizeChartJson { get; set; }

        // Boolean property to indicate if the product is a top (e.g., shirts, blouses) or a bottom (e.g., pants, skirts).
        public bool IsTop { get; set; }

        // Optional property to define the color of the product.
        public string Color { get; set; }

        // Stock quantity with validation to ensure it is non-negative.
        [Range(0, int.MaxValue, ErrorMessage = "Stock must be 0 or greater.")]
        public int Stock { get; set; }

        // Required field to specify the material of the product, with a default empty value to avoid null issues.
        [Required(ErrorMessage = "Material is required.")]
        public string Material { get; set; } = string.Empty;

        // Optional description of the product to provide additional details to users.
        public string? Description { get; set; }

        // Optional field for special tags (e.g., "New Arrival", "On Sale").
        public string? SpecialTag { get; set; }

        // Foreign key to the Category table, ensuring that every product belongs to a category.
        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }

        // Navigation property to link the Product to its Category entity using the foreign key.
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        // Optional property to store the URL of the product image.
        public string? ImageUrl { get; set; }
    }



}
