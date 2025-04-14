using BlazorWeb.Models;
using System.Net.Http.Json;

namespace BlazorWeb.Components.Service
{
    public class PromotionService
    {
        private readonly HttpClient _httpClient;

        public PromotionService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BlazorAPI");
        }

        public async Task<List<Promotion>> GetPromotionsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Promotion>>("api/Promotion");
        }

        public async Task<Promotion> GetPromotionByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Promotion>($"api/Promotion/{id}");
        }

        public async Task AddPromotionAsync(Promotion promotion)
        {
            await _httpClient.PostAsJsonAsync("api/Promotion", promotion);
        }

        public async Task UpdatePromotionAsync(Promotion promotion)
        {
            await _httpClient.PutAsJsonAsync($"api/Promotion/{promotion.PromotionId}", promotion);
        }

        public async Task DeletePromotionAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Promotion/{id}");
        }
    }
}
