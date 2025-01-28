using Microsoft.EntityFrameworkCore;
using PresizelyWeb.Data;
using PresizelyWeb.Repository.IRepository;
using Stripe;

namespace PresizelyWeb.Repository
{
    // Repository implementation for managing OrderHeader data.
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _db;

        // Constructor to initialize the database context.
        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        // Creates a new OrderHeader in the database.
        public async Task<OrderHeader> CreateAsync(OrderHeader orderHeader)
        {
            try
            {
                // Set OrderDate to now if not provided.
                if (orderHeader.OrderDate == DateTime.MinValue)
                {
                    orderHeader.OrderDate = DateTime.Now;
                }

                await _db.OrderHeader.AddAsync(orderHeader);
                await _db.SaveChangesAsync();
                return orderHeader;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving order: {ex.Message}");
                throw;
            }
        }

        // Retrieves all OrderHeaders, optionally filtered by user ID.
        public async Task<IEnumerable<OrderHeader>> GetAllAsync(string? userId = null)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                return await _db.OrderHeader.Where(u => u.UserId == userId).ToListAsync();
            }
            return await _db.OrderHeader.ToListAsync();
        }

        // Retrieves a single OrderHeader by its ID, including its OrderDetails.
        public async Task<OrderHeader> GetAsync(int id)
        {
            return await _db.OrderHeader.Include(u => u.OrderDetails).FirstOrDefaultAsync(u => u.Id == id);
        }

        // Retrieves an OrderHeader by its Stripe session ID.
        public async Task<OrderHeader> GetOrderBySessionIdAsync(string sessionId)
        {
            return await _db.OrderHeader.FirstOrDefaultAsync(u => u.SessionId == sessionId.ToString());
        }

        // Updates the status of an OrderHeader and optionally sets the payment intent ID.
        public async Task<OrderHeader> UpdateStatusAsync(int orderId, string status, string paymentIntentId)
        {
            var orderHeader = await _db.OrderHeader.FirstOrDefaultAsync(u => u.Id == orderId);

            if (orderHeader != null)
            {
                orderHeader.Status = status;

                if (!string.IsNullOrEmpty(paymentIntentId))
                {
                    orderHeader.PaymentIntentId = paymentIntentId;
                }
                await _db.SaveChangesAsync();
            }
            return orderHeader;
        }
    }
}
