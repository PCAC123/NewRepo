using BlazorWeb.Models;
using System.Net.Http.Json;

namespace BlazorWeb.Components.Service
{
    public class PaymentsService
    {
        private readonly HttpClient _httpClient;

        public PaymentsService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BlazorAPI");
        }

        public async Task<List<Payment>> GetPaymentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Payment>>("api/Payment");
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Payment>($"api/Payment/{id}");
        }

        public async Task AddPaymentAsync(Payment payment)
        {
            await _httpClient.PostAsJsonAsync("api/Payment", payment);
        }

        public async Task UpdatePaymentAsync(Payment payment)
        {
            await _httpClient.PutAsJsonAsync($"api/Payment/{payment.PaymentId}", payment);
        }

        public async Task DeletePaymentAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Payment/{id}");
        }
    }
}
