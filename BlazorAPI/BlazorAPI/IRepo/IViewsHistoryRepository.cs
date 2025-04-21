using BlazorAPI.Models;

namespace BlazorAPI.IRepo
{
    public interface IViewsHistoryRepository
    {
        Task<List<ViewHistory>> GetAllViewsAsync();
        Task<List<ViewHistory>> GetViewsByUserIdAsync(int userId);
        Task AddViewAsync(ViewHistory history);
        Task DeleteViewAsync(int id);
    }
}
