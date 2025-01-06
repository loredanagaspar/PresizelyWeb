using PresizelyWeb.Data;

namespace PresizelyWeb.Repository.IRepository
{
    public interface IShoppingCartRepository
    {
        public Task<bool> UpdateCartAsync(string userId, int product, int updateBy, string size);
        public Task<IEnumerable<ShoppingCart>> GetAllAsync(string? userId);
        public Task<bool> ClearCartAsync(string? userId);
        public Task<bool> RemoveCartItemAsync(string userId, int productId, string size);

        public Task <int> GetTotalCartCountAsync(string? userId);

    }
}
