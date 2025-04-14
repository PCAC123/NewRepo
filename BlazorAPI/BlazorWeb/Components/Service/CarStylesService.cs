using BlazorWeb.Models;

namespace BlazorWeb.Components.Service
{
    public class CarStylesService
    {
        private readonly HttpClient _httpClient;
        public CarStylesService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BlazorAPI");
        }
        public async Task<List<CarStyle>> GetCarStylesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<CarStyle>>("api/CarsStyle");
        }
        public async Task<CarStyle> GetCarStylesByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<CarStyle>($"api/CarsStyle/{id}");
        }
        public async Task AddCarStyleAsync(CarStyle product)
        {
            await _httpClient.PostAsJsonAsync("api/CarsStyle", product);
        }

        public async Task UpdateCarStyleAsync(CarStyle product)
        {
            await _httpClient.PutAsJsonAsync($"api/CarsStyle/{product.StyleId}", product);
        }

        public async Task DeleteCarStyleAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/CarsStyle/{id}");
        }
    }
}
