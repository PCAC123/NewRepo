using BlazorAPI.Models;

namespace BlazorAPI.IRepo
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAllPaymentsAsync();
        Task<Payment?> GetPaymentByIdAsync(int id);
        Task AddPaymentAsync(Payment payment);
        Task RemovePaymentAsync(int id);
        Task UpdatePaymentAsync(Payment payment);
    }
}
