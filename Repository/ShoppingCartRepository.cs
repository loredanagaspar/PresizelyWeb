using Microsoft.EntityFrameworkCore;
using PresizelyWeb.Data;
using PresizelyWeb.Repository.IRepository;

namespace PresizelyWeb.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ApplicationDbContext _db;

        public ShoppingCartRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> ClearCartAsync(string? userId)
        {
            var cartItems = await _db.ShoppingCart.Where(u => u.UserId == userId).ToListAsync();
            _db.ShoppingCart.RemoveRange(cartItems);
            return await _db.SaveChangesAsync() > 0;

        }

        public async Task<IEnumerable<ShoppingCart>> GetAllAsync(string? userId)
        {
            return await _db.ShoppingCart.Where(u => u.UserId == userId).Include(u => u.Product).ToListAsync();
        }

        public async Task<bool> UpdateCartAsync(string userId, int productId, int updateBy, string size)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(size))
            {
                return false;
            }

            var cart = await _db.ShoppingCart.FirstOrDefaultAsync(u => u.UserId == userId && u.ProductId == productId && u.Size == size);

            if (cart == null)
            {
                cart = new ShoppingCart
                {
                    UserId = userId,
                    ProductId = productId,
                    Count = updateBy > 0 ? updateBy : 1, // Ensure at least 1 item is added
                    Size =size

                };

                await _db.ShoppingCart.AddAsync(cart);

            }
            else
            {
                cart.Count += updateBy;
                if (cart.Count <= 0)
                {
                    {
                        _db.ShoppingCart.Remove(cart);
                    }

                }

            }

            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveCartItemAsync(string userId, int productId, string size)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(size))
            {
                return false;
            }

            // Fetch the specific cart item
            var cart = await _db.ShoppingCart.FirstOrDefaultAsync(u => u.UserId == userId && u.ProductId == productId && u.Size == size);

            if (cart != null)
            {
                _db.ShoppingCart.Remove(cart);
                return await _db.SaveChangesAsync() > 0;
            }

            return false; // No action if the item doesn't exist
        }

    }
}