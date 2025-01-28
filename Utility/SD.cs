using PresizelyWeb.Data;

namespace PresizelyWeb.Utility
{
    // Static utility class for storing shared constants and methods
    public static class SD
    {
        // Role constants for user roles in the system
        public static string Role_Admin = "Admin"; // Represents the Admin role
        public static string Role_Customer = "Customer"; // Represents the Customer role

        // Status constants for tracking order status
        public static string StatusPending = "Pending"; // Order is pending approval
        public static string StatusApproved = "Approved"; // Order has been approved
        public static string StatusReadyForDelivery = "ReadyForDelivery"; // Order is ready for delivery
        public static string StatusCompleted = "Completed"; // Order has been successfully completed
        public static string StatusCancelled = "Cancelled"; // Order has been cancelled

        // Method to convert a list of shopping cart items into a list of order details
        public static List<OrderDetail> ConvertShoppingCartListOrderDetail(List<ShoppingCart> shoppingCarts)
        {
            // Initialize an empty list to store the converted OrderDetail objects
            List<OrderDetail> orderDetails = new List<OrderDetail>();

            // Loop through each shopping cart item
            foreach (var cart in shoppingCarts)
            {
                // Create a new OrderDetail object for each cart item
                OrderDetail orderDetail = new OrderDetail
                {
                    ProductId = cart.ProductId, // Map the ProductId from the cart
                    Count = cart.Count, // Map the quantity of the product
                    Price = Convert.ToDouble(cart.Product.Price), // Convert and map the product price
                    Size = cart.Size, // Map the selected size of the product
                    ProductName = cart.Product.Name // Map the name of the product
                };

                // Add the created OrderDetail object to the list
                orderDetails.Add(orderDetail);
            }

            // Return the list of converted OrderDetail objects
            return orderDetails;
        }
    }
}
