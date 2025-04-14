using BlazorAPI.IRepo;
using BlazorAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentRepository _repository;

        public PaymentController(IPaymentRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Payment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetAll()
        {
            var payments = await _repository.GetAllPaymentsAsync();
            return Ok(payments);
        }

        // GET: api/Payment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetById(int id)
        {
            var payment = await _repository.GetPaymentByIdAsync(id);
            if (payment == null)
                return NotFound();

            return Ok(payment);
        }

        // POST: api/Payment
        [HttpPost]
        public async Task<ActionResult> Create(Payment payment)
        {
            await _repository.AddPaymentAsync(payment);
            return CreatedAtAction(nameof(GetById), new { id = payment.PaymentId }, payment);
        }

        // PUT: api/Payment/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Payment payment)
        {
            if (id != payment.PaymentId)
                return BadRequest("ID không khớp");

            await _repository.UpdatePaymentAsync(payment);
            return NoContent();
        }

        // DELETE: api/Payment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.RemovePaymentAsync(id);
            return NoContent();
        }
    }
}
