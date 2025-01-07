using Microsoft.EntityFrameworkCore;
using PresizelyWeb.Data;
using PresizelyWeb.Repository.IRepository;
using Stripe;

namespace PresizelyWeb.Repository
{
    public class OrderRepository : IOrderRepository
    {

        private readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<OrderHeader> CreateAsync(OrderHeader orderHeader)
        {
            try
            {
                // Ensure OrderDate is set before saving
                if (orderHeader.OrderDate == DateTime.MinValue)
                {
                    orderHeader.OrderDate = DateTime.Now;
                }

                Console.WriteLine($"Saving order with OrderDate: {orderHeader.OrderDate}");
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

        public async Task<IEnumerable<OrderHeader>> GetAllAsync(string? userId = null)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                return await _db.OrderHeader.Where(u => u.UserId == userId).ToListAsync();
            }
            return await _db.OrderHeader.ToListAsync();
        }

        public async Task<OrderHeader> GetAsync(int id)
        {
            return await _db.OrderHeader.Include(u => u.OrderDetails).FirstOrDefaultAsync(u=>u.Id == id);
        }

        public async Task<OrderHeader> GetOrderBySessionIdAsync(string sessionId)
        {
            return await _db.OrderHeader.FirstOrDefaultAsync(u => u.SessionId == sessionId.ToString());
        }

        public async Task<OrderHeader> UpdateStatusAsync(int orderId, string status, string paymentIntentId)
        {
            var orderHeader= await _db.OrderHeader.FirstOrDefaultAsync(u=>u.Id==orderId);

            if (orderHeader != null)

            {
                orderHeader.Status = status;

                if(!string.IsNullOrEmpty(paymentIntentId))
                {
                    orderHeader.PaymentIntentId = paymentIntentId;
                }
                await _db.SaveChangesAsync();
            }
            return orderHeader;

        }
    }
}
