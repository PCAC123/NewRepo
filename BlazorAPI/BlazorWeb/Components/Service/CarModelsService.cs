using BlazorWeb.Models;

namespace BlazorWeb.Components.Service
{
    public class CarModelsService
    {
        private readonly HttpClient _httpClient;
        //userservice
        public CarModelsService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BlazorAPI");
        }

        public async Task<List<CarModel>> GetCarModelsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<CarModel>>("api/CarsModel");
        }
        public async Task<CarModel> GetCarModelsByIdWebAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<CarModel>($"api/CarsModel/{id}");
        }
        public async Task AddCarModelsAsync(CarModel product)
        {
            await _httpClient.PostAsJsonAsync("api/CarsModel", product);
        }

        public async Task UpdateCarModelsAsync(CarModel product)
        {
            await _httpClient.PutAsJsonAsync($"api/CarsModel/{product.ModelId}", product);
        }

        public async Task DeleteCarModelsAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/CarsModel/{id}");
        }
    }
}
