using System.ComponentModel.DataAnnotations;

namespace PresizelyWeb.Data
{
    public class OrderHeader
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Order total is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Order total must be greater than 0.")]
        [Display(Name = "Order Total")]
        public double OrderTotal { get; set; }

        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^0[1-9]\d{9}$", ErrorMessage = "Enter a valid UK phone number (e.g., 07466480661).")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Delivery address is required.")]
        [Display(Name = "Delivery Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Postal code is required.")]
        [RegularExpression(@"^([A-Z]{1,2}\d{1,2}[A-Z]?)\s?(\d[A-Z]{2})$", ErrorMessage = "Invalid UK postal code format.")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [Display(Name = "City")]
        public string City { get; set; }

        public string? SessionId { get; set; }
        public string? PaymentIntentId { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }



    }
}

