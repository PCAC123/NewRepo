using BlazorAPI.Models;

namespace BlazorAPI.IRepo
{
    public interface IPromotionRepository
    {
        Task<List<Promotion>> GetAllPromotionsAsync();
        Task<Promotion?> GetPromotionByIdAsync(int id);
        Task AddPromotionAsync(Promotion promotion);
        Task RemovePromotionAsync(int id);
        Task UpdatePromotionAsync(Promotion promotion);
    }
}
