using BlazorWeb.Models;

namespace BlazorWeb.Components.Service
{
    public class OrdersService
    {
        private readonly HttpClient _httpClient;
        //userservice
        public OrdersService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BlazorAPI");
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Order>>("api/Orders");
        }
        public async Task<Order> GetProductByIdWebAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Order>($"api/Orders/{id}");
        }
        public async Task<Order?> AddOrderAsync(Order order)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Orders", order);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Order>();
            }
            return null;    
        }


        //public async Task UpdateOrderAsync(Order product)
        //{
        //    await _httpClient.PutAsJsonAsync($"api/Orders/{product.OrderId}", product);
        //}

        //public async Task DeleteOrderAsync(int id)
        //{
        //    await _httpClient.DeleteAsync($"api/Orders/{id}");
        //}
    }
}
