using System.ComponentModel.DataAnnotations;

namespace PresizelyWeb.Data
{    
     /// Represents the header information for an order, 
     /// including customer details, order totals, payment status, and delivery address.
    public class OrderHeader
    {
        // Unique identifier for the order.
        public int Id { get; set; }

        // ID of the user who placed the order. Required field.
        [Required(ErrorMessage = "User ID is required.")]
        public string UserId { get; set; }

        // Total cost of the order. Must be greater than 0. Required field.
        [Required(ErrorMessage = "Order total is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Order total must be greater than 0.")]
        [Display(Name = "Order Total")]
        public double OrderTotal { get; set; }

        // Date and time when the order was placed.
        public DateTime OrderDate { get; set; }

        // Current status of the order (e.g., Pending, Approved, Shipped). Required field.
        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }

        // Name of the customer placing the order. Required field.
        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        // Phone number of the customer. Must follow a UK phone number format. Required field.
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^0[1-9]\d{9}$", ErrorMessage = "Enter a valid UK phone number (e.g., 07466480661).")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        // Email address of the customer. Must be in a valid email format. Required field.
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        // Delivery address for the order. Required field.
        [Required(ErrorMessage = "Delivery address is required.")]
        [Display(Name = "Delivery Address")]
        public string Address { get; set; }

        // Postal code for the delivery address. Must follow a valid UK postal code format. Required field.
        [Required(ErrorMessage = "Postal code is required.")]
        [RegularExpression(@"^([A-Z]{1,2}\d{1,2}[A-Z]?)\s?(\d[A-Z]{2})$", ErrorMessage = "Invalid UK postal code format.")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        // City for the delivery address. Required field.
        [Required(ErrorMessage = "City is required.")]
        [Display(Name = "City")]
        public string City { get; set; }

        // Stripe session ID for the payment process (optional).
        public string? SessionId { get; set; }

        // Stripe payment intent ID for tracking the payment status (optional).
        public string? PaymentIntentId { get; set; }

        // Collection of order details linked to this order.
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

