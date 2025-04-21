using BlazorWeb.Models;

namespace BlazorWeb.Components.Service
{
    public class OrderDetailsService
    {
        private readonly HttpClient _httpClient;
        //userservice
        public OrderDetailsService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BlazorAPI");
        }

        public async Task<List<OrderDetail>> GetOrderDetailsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<OrderDetail>>("api/OrderDetails");
        }
        public async Task<OrderDetail> GetProductByIdWebAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<OrderDetail>($"api/OrderDetails/{id}");
        }
        public async Task AddOrderDetailAsync(OrderDetail product)
        {
            await _httpClient.PostAsJsonAsync("api/OrderDetails", product);
        }

        //public async Task UpdateOrderDetailAsync(OrderDetail product)
        //{
        //    await _httpClient.PutAsJsonAsync($"api/OrderDetails/{product.OrderDetailId}", product);
        //}

        //public async Task DeleteOrderDetailAsync(int id)
        //{
        //    await _httpClient.DeleteAsync($"api/OrderDetails/{id}");
        //}
    }
}
