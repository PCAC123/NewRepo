using BlazorAPI.IRepo;
using BlazorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Data
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ApplicationDbContext _context;

        public OrdersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllOrderAsync()
        {
            return await _context.OrdersDb
                .Include(o => o.User)
                .Include(o => o.Payment)
                .Include(o => o.Promotion)
                .Include(o => o.OrderDetails)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.OrdersDb
                .Include(o => o.User)
                .Include(o => o.Payment)
                .Include(o => o.Promotion)
                .Include(o => o.OrderDetails)
                .AsNoTracking()
                .FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task AddrderAsync(Order order)
        {
            await _context.OrdersDb.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverderAsync(int id)
        {
            var order = await _context.OrdersDb.FindAsync(id);
            if (order != null)
            {
                _context.OrdersDb.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdaterderAsync(Order order)
        {
            var existingOrder = await _context.OrdersDb
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.OrderId == order.OrderId);

            if (existingOrder != null)
            {
                existingOrder.UserId = order.UserId;
                existingOrder.PaymentId = order.PaymentId;
                existingOrder.PromotionId = order.PromotionId;
                existingOrder.OrderDate = order.OrderDate;
                existingOrder.TotalPrice = order.TotalPrice;
                existingOrder.Status = order.Status;

                // Optionally update OrderDetails if needed
                // existingOrder.OrderDetails = order.OrderDetails;

                _context.OrdersDb.Update(existingOrder);
                await _context.SaveChangesAsync();
            }
        }
    }
}
