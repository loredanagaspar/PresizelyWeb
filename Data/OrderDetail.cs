using System.ComponentModel.DataAnnotations;

namespace PresizelyWeb.Data
{
    /// <summary>
    /// Represents the details of a specific order, including product information, quantity, and pricing.
    /// </summary>
    public class OrderDetail
        {
            // Unique identifier for the order detail.
            public int Id { get; set; }

            // Identifier for the associated order header, linking this detail to the main order.
            public int OrderHeaderId { get; set; }

            // The associated order header, providing access to the main order.
            public OrderHeader OrderHeader { get; set; }

            // Identifier of the product associated with this order detail.
            public int ProductId { get; set; }

            // The associated product details, providing access to product-related information.
            public Product Product { get; set; }

            // Quantity of the product ordered. Required field.
            [Required]
            public int Count { get; set; }

            // Price of the product at the time of the order. Required field.
            [Required]
            public double Price { get; set; }

            // Name of the product associated with this order detail. Required field.
            [Required]
            public string ProductName { get; set; }

            // Size of the product ordered. Required field.
            [Required]
            public string Size { get; set; }
        }
}
