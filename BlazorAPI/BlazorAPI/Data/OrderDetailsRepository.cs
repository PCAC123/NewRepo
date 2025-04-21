using BlazorAPI.IRepo;
using BlazorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Data
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderDetail>> GetAllDetailsAsync()
        {
            return await _context.OrderDetailsDb
                .Include(od => od.Order)
                .Include(od => od.Car)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<OrderDetail>> GetByOrderIdAsync(int orderId)
        {
            return await _context.OrderDetailsDb
                .Where(od => od.OrderId == orderId)
                .Include(od => od.Car)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddDetailAsync(OrderDetail detail)
        {
            await _context.OrderDetailsDb.AddAsync(detail);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveDetailAsync(int id)
        {
            var detail = await _context.OrderDetailsDb.FindAsync(id);
            if (detail != null)
            {
                _context.OrderDetailsDb.Remove(detail);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateDetailAsync(OrderDetail detail)
        {
            var existing = await _context.OrderDetailsDb.FindAsync(detail.OrderDetailId);
            if (existing != null)
            {
                existing.CarId = detail.CarId;
                existing.Price = detail.Price;
                existing.OrderId = detail.OrderId;

                _context.OrderDetailsDb.Update(existing);
                await _context.SaveChangesAsync();
            }
        }
    }

}
