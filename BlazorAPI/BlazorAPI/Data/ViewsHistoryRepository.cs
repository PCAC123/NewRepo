using BlazorAPI.IRepo;
using BlazorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Data
{
    public class ViewsHistoryRepository : IViewsHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ViewsHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ViewHistory>> GetAllViewsAsync()
        {
            return await _context.ViewHistoriesDb
                .Include(v => v.User)
                .Include(v => v.Car)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<ViewHistory>> GetViewsByUserIdAsync(int userId)
        {
            return await _context.ViewHistoriesDb
                .Where(v => v.UserId == userId)
                .Include(v => v.Car)
                .OrderByDescending(v => v.ViewedAt)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddViewAsync(ViewHistory history)
        {
            await _context.ViewHistoriesDb.AddAsync(history);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteViewAsync(int id)
        {
            var view = await _context.ViewHistoriesDb.FindAsync(id);
            if (view != null)
            {
                _context.ViewHistoriesDb.Remove(view);
                await _context.SaveChangesAsync();
            }
        }
    }

}
