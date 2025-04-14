using BlazorAPI.IRepo;
using BlazorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Data
{
    public class CarsStyleRepository : ICarsStyleRepository
    {
        private readonly ApplicationDbContext _context; 

        public CarsStyleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CarStyle>> GetAllStylesAsync() =>
            await _context.CarStylesDb.AsNoTracking().ToListAsync();

        public async Task<CarStyle?> GetStyleByIdAsync(int id) =>
            await _context.CarStylesDb.AsNoTracking().FirstOrDefaultAsync(s => s.StyleId == id);

        public async Task AddStyleAsync(CarStyle style)
        {
            await _context.CarStylesDb.AddAsync(style);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveStyleAsync(int id)
        {
            var style = await _context.CarStylesDb.FindAsync(id);
            if (style != null)
            {
                _context.CarStylesDb.Remove(style);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateStyleAsync(CarStyle updatedStyle)
        {
            var existingStyle = await _context.CarStylesDb.FindAsync(updatedStyle.StyleId);
            if (existingStyle != null)
            {
                existingStyle.StyleName = updatedStyle.StyleName;
                _context.CarStylesDb.Update(existingStyle);
                await _context.SaveChangesAsync();
            }
        }
    }
}
