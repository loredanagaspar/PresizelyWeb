using PresizelyWeb.Data;

namespace PresizelyWeb.Repository.IRepository
{
    // Interface for managing Order-related data operations.
    public interface IOrderRepository
    {
        // Creates a new OrderHeader in the database.
        // Parameter: orderHeader - The OrderHeader object to create.
        // Returns: The created OrderHeader object.
        public Task<OrderHeader> CreateAsync(OrderHeader orderHeader);

        // Retrieves a single OrderHeader by its ID.
        // Parameter: id - The ID of the OrderHeader to retrieve.
        // Returns: The OrderHeader object if found, or null if not found.
        public Task<OrderHeader> GetAsync(int id);

        // Retrieves an OrderHeader by its Stripe session ID.
        // Parameter: sessionId - The Stripe session ID associated with the order.
        // Returns: The corresponding OrderHeader object.
        public Task<OrderHeader> GetOrderBySessionIdAsync(string sessionId);

        // Retrieves all OrderHeaders, optionally filtered by user ID.
        // Parameter: userId (optional) - The ID of the user whose orders should be retrieved.
        // Returns: A collection of OrderHeader objects for the specified user or all users if no userId is provided.
        public Task<IEnumerable<OrderHeader>> GetAllAsync(string? userId = null);

        // Updates the status of an order in the database.
        // Parameters:
        //   orderId - The ID of the order to update.
        //   status - The new status to assign to the order.
        //   paymentIntentId - The payment intent ID to associate with the order.
        // Returns: The updated OrderHeader object.
        public Task<OrderHeader> UpdateStatusAsync(int orderId, string status, string paymentIntentId);
    }
}
