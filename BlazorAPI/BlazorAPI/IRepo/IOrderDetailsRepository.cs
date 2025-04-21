using BlazorAPI.Models;

namespace BlazorAPI.IRepo
{
    public interface IOrderDetailsRepository
    {
        Task<List<OrderDetail>> GetAllDetailsAsync();
        Task<List<OrderDetail>> GetByOrderIdAsync(int orderId);
        Task AddDetailAsync(OrderDetail detail);
        Task RemoveDetailAsync(int id);
        Task UpdateDetailAsync(OrderDetail detail);
    }
}
