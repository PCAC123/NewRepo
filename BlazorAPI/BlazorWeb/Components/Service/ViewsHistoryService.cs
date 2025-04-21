using BlazorWeb.Models;

namespace BlazorWeb.Components.Service
{
    public class ViewsHistoryService
    {
        private readonly HttpClient _httpClient;
        //userservice
        public ViewsHistoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BlazorAPI");
        }

        public async Task<List<ViewHistory>> GetViewsHistoryAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ViewHistory>>("api/ViewHistory");
        }
        public async Task<List<ViewHistory>> GetViewHisByIdWebAsync(int userId)
        {
            return await _httpClient.GetFromJsonAsync<List<ViewHistory>>($"api/ViewHistory/user/{userId}");
        }

        public async Task AddViewHistoryAsync(ViewHistory product)
        {
            await _httpClient.PostAsJsonAsync("api/ViewHistory", product);
        }

        //public async Task UpdateViewHistoryAsync(ViewHistory product)
        //{
        //    await _httpClient.PutAsJsonAsync($"api/ViewHistory/{product.ViewId}", product);
        //}

        public async Task DeleteViewHistoryAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/ViewHistory/{id}");
        }
    }
}
