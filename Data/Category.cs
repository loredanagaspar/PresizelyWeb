using System.ComponentModel.DataAnnotations;

namespace PresizelyWeb.Data
{
    /// <summary>
    /// Represents a category of products in the application.
    /// </summary>
    public class Category
    {
        /// Gets or sets the unique identifier for the category.
        
        public int Id { get; set; }

        /// Gets or sets the name of the category.
        /// This field is required and must not be empty.
  
        [Required(ErrorMessage = "Please enter name.")] // Validation attribute to ensure the name is provided
        public string Name { get; set; }
    }

}
