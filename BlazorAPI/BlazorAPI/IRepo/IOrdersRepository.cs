using BlazorAPI.Models;

namespace BlazorAPI.IRepo
{
    public interface IOrdersRepository
    {
        Task<List<Order>> GetAllOrderAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task AddrderAsync(Order order);
        Task RemoverderAsync(int id);
        Task UpdaterderAsync(Order order); // Cập nhật sản phẩm
    }
}
