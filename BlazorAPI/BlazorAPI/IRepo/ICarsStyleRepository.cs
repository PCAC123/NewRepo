using BlazorAPI.Models;

namespace BlazorAPI.IRepo
{
    public interface ICarsStyleRepository
    {
        Task<List<CarStyle>> GetAllStylesAsync();
        Task<CarStyle?> GetStyleByIdAsync(int id);
        Task AddStyleAsync(CarStyle style);
        Task RemoveStyleAsync(int id);
        Task UpdateStyleAsync(CarStyle style); // Cập nhật style
    }
}
