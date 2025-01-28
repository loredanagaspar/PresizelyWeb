using PresizelyWeb.Data;

namespace PresizelyWeb.Repository.IRepository
{
    // Interface for managing Shopping Cart-related data operations.
    public interface IShoppingCartRepository
    {
        // Updates the quantity of a product in the shopping cart.
        // Parameters:
        //   userId - The ID of the user whose cart is being updated.
        //   product - The ID of the product being updated.
        //   updateBy - The quantity to add or subtract.
        //   size - The size of the product being updated.
        // Returns: True if the update was successful, false otherwise.
        public Task<bool> UpdateCartAsync(string userId, int product, int updateBy, string size);

        // Retrieves all items in the shopping cart for a specific user.
        // Parameter: userId (optional) - The ID of the user whose cart items should be retrieved.
        // Returns: A collection of ShoppingCart objects for the specified user.
        public Task<IEnumerable<ShoppingCart>> GetAllAsync(string? userId);

        // Clears all items in the shopping cart for a specific user.
        // Parameter: userId (optional) - The ID of the user whose cart should be cleared.
        // Returns: True if the cart was successfully cleared, false otherwise.
        public Task<bool> ClearCartAsync(string? userId);

        // Removes a specific item from the shopping cart.
        // Parameters:
        //   userId - The ID of the user whose cart item should be removed.
        //   productId - The ID of the product to remove.
        //   size - The size of the product to remove.
        // Returns: True if the item was successfully removed, false otherwise.
        public Task<bool> RemoveCartItemAsync(string userId, int productId, string size);

        // Retrieves the total count of items in the shopping cart for a specific user.
        // Parameter: userId (optional) - The ID of the user whose cart total count should be retrieved.
        // Returns: The total number of items in the shopping cart.
        public Task<int> GetTotalCartCountAsync(string? userId);
    }
}
