using BlazorAPI.IRepo;
using BlazorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Data
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Payment>> GetAllPaymentsAsync() =>
            await _context.PaymentsDb.AsNoTracking().ToListAsync();

        public async Task<Payment?> GetPaymentByIdAsync(int id) =>
            await _context.PaymentsDb.AsNoTracking().FirstOrDefaultAsync(p => p.PaymentId == id);

        public async Task AddPaymentAsync(Payment payment)
        {
            await _context.PaymentsDb.AddAsync(payment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePaymentAsync(Payment updatedPayment)
        {
            var existing = await _context.PaymentsDb.FindAsync(updatedPayment.PaymentId);
            if (existing != null)
            {
                existing.PaymentMethod = updatedPayment.PaymentMethod;
                existing.PaymentStatus = updatedPayment.PaymentStatus;
                existing.PaidAt = updatedPayment.PaidAt;

                await _context.SaveChangesAsync();
            }
        }

        public async Task RemovePaymentAsync(int id)
        {
            var payment = await _context.PaymentsDb.FindAsync(id);
            if (payment != null)
            {
                _context.PaymentsDb.Remove(payment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
