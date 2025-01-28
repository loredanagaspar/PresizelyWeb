using System.ComponentModel.DataAnnotations.Schema;

namespace PresizelyWeb.Data
{
    /// <summary>
    /// Represents an item in a user's shopping cart, including the product, quantity, and size selected.
    /// </summary>
    public class ShoppingCart
    {
        public int Id { get; set; } // Unique identifier for the shopping cart entry.

        public string UserId { get; set; } // The ID of the user who owns the shopping cart.

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; } // The user associated with this shopping cart entry.

        public int ProductId { get; set; } // The ID of the product added to the shopping cart.

        [ForeignKey("ProductId")]
        public Product Product { get; set; } // The product associated with this shopping cart entry.

        public int Count { get; set; } // The quantity of the product in the shopping cart.

        public string Size { get; set; } // The size of the product selected by the user.
    }

}

