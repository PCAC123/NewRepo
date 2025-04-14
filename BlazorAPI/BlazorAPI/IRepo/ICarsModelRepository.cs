using BlazorAPI.Models;

namespace BlazorAPI.IRepo
{
    public interface ICarsModelRepository
    {
        Task<List<CarModel>> GetAllCarModelsAsync();
        Task<CarModel> GetCarModelByIdAsync(int id);
        Task AddCarModelAsync(CarModel product);
        Task RemoveCarModelAsync(int id);
        Task UpdateCarModelAsync(CarModel product); // Cập nhật sản phẩm
    }
}
