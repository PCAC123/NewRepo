using BlazorWeb.Models;

namespace BlazorWeb.Components.Service
{
    public class CarsService
    {//userservice
        private readonly HttpClient _httpClient;
        //userservice
        public CarsService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BlazorAPI");
        }
        
        public async Task<List<Car>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Car>>("api/Cars");
        }
        public async Task<Car> GetProductByIdWebAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Car>($"api/Cars/{id}");
        }
        public async Task AddProductAsync(Car product)
        {
            await _httpClient.PostAsJsonAsync("api/Cars", product);
        }

        public async Task UpdateProductAsync(Car product)
        {
            await _httpClient.PutAsJsonAsync($"api/Cars/{product.CarId}", product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Cars/{id}");
        }
    }
}
