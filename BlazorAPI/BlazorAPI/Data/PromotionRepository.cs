using BlazorAPI.IRepo;
using BlazorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Data
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly ApplicationDbContext _context;

        public PromotionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Promotion>> GetAllPromotionsAsync() =>
            await _context.PromotionsDb.AsNoTracking().ToListAsync();

        public async Task<Promotion?> GetPromotionByIdAsync(int id) =>
            await _context.PromotionsDb.AsNoTracking().FirstOrDefaultAsync(p => p.PromotionId == id);

        public async Task AddPromotionAsync(Promotion promotion)
        {
            await _context.PromotionsDb.AddAsync(promotion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePromotionAsync(Promotion updated)
        {
            var existing = await _context.PromotionsDb.FindAsync(updated.PromotionId);
            if (existing != null)
            {
                existing.DiscountPercentage = updated.DiscountPercentage;
                existing.StartDate = updated.StartDate;
                existing.EndDate = updated.EndDate;

                await _context.SaveChangesAsync();
            }
        }

        public async Task RemovePromotionAsync(int id)
        {
            var promo = await _context.PromotionsDb.FindAsync(id);
            if (promo != null)
            {
                _context.PromotionsDb.Remove(promo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
