using BlazorAPI.Models;

namespace BlazorAPI.IRepo
{
    public interface ICarsRepository
    {
        Task<List<Car>> GetAllProductsAsync();
        Task<Car> GetProductByIdAsync(int id);
        Task AddProductAsync(Car product);
        Task RemoveProductAsync(int id);
        Task UpdateProductAsync(Car product); // Cập nhật sản phẩm
    }
}
