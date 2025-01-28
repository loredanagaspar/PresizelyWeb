using Microsoft.EntityFrameworkCore;
using PresizelyWeb.Data;
using PresizelyWeb.Repository.IRepository;

namespace PresizelyWeb.Repository
{
    // Repository implementation for managing ShoppingCart data.
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ApplicationDbContext _db;

        // Constructor to initialize the database context.
        public ShoppingCartRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        // Clears all cart items for a specific user.
        public async Task<bool> ClearCartAsync(string? userId)
        {
            var cartItems = await _db.ShoppingCart.Where(u => u.UserId == userId).ToListAsync();
            _db.ShoppingCart.RemoveRange(cartItems);
            return await _db.SaveChangesAsync() > 0; // Returns true if items were cleared.
        }

        // Retrieves all cart items for a specific user, including product details.
        public async Task<IEnumerable<ShoppingCart>> GetAllAsync(string? userId)
        {
            return await _db.ShoppingCart
                .Where(u => u.UserId == userId)
                .Include(u => u.Product) // Include related Product details.
                .ToListAsync();
        }

        // Updates the quantity of a product in the shopping cart or adds a new item.
        public async Task<bool> UpdateCartAsync(string userId, int productId, int updateBy, string size)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(size))
            {
                return false; // Invalid user or size.
            }

            var cart = await _db.ShoppingCart.FirstOrDefaultAsync(u => u.UserId == userId && u.ProductId == productId && u.Size == size);

            if (cart == null)
            {
                // Add a new cart item if it doesn't exist.
                cart = new ShoppingCart
                {
                    UserId = userId,
                    ProductId = productId,
                    Count = updateBy > 0 ? updateBy : 1, // Ensure at least 1 item is added.
                    Size = size
                };
                await _db.ShoppingCart.AddAsync(cart);
            }
            else
            {
                // Update the existing cart item.
                cart.Count += updateBy;
                if (cart.Count <= 0)
                {
                    // Remove the item if the count is zero or less.
                    _db.ShoppingCart.Remove(cart);
                }
            }

            return await _db.SaveChangesAsync() > 0;
        }

        // Removes a specific item from the shopping cart.
        public async Task<bool> RemoveCartItemAsync(string userId, int productId, string size)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(size))
            {
                return false; // Invalid user or size.
            }

            var cart = await _db.ShoppingCart.FirstOrDefaultAsync(u => u.UserId == userId && u.ProductId == productId && u.Size == size);

            if (cart != null)
            {
                _db.ShoppingCart.Remove(cart);
                return await _db.SaveChangesAsync() > 0; // Returns true if the item was removed.
            }

            return false; // No action if the item doesn't exist.
        }

        // Retrieves the total number of items in the shopping cart for a user.
        public async Task<int> GetTotalCartCountAsync(string? userId)
        {
            int cartCount = 0;
            var cartItems = await _db.ShoppingCart.Where(u => u.UserId == userId).ToListAsync();

            // Sum up the counts of all cart items.
            foreach (var item in cartItems)
            {
                cartCount += item.Count;
            }

            return cartCount;
        }
    }
}
