using BlazorWeb.Models;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;

namespace BlazorWeb.Components.Service
{
    public class UsersService
    {
        private readonly HttpClient _httpClient;
        public UsersService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BlazorAPI");
        }
        public async Task<User?> LoginAsync(string email, string password)
        {
            var users = await GetUsersAsync();

            // Hash password nhập vào
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = sha256.ComputeHash(bytes);
            string hashedPassword = Convert.ToHexString(hashBytes);

            // Tìm user khớp email + hash
            return users.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
                u.PasswordHash == hashedPassword
            );
        }
        public async Task<bool> IsEmailTakenAsync(string email)
        {
            var users = await GetUsersAsync();
            return users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<User>>("api/Users");
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<User>($"api/Users/{id}");
        }

        public async Task AddUserAsync(User user)
        {
            await _httpClient.PostAsJsonAsync("api/Users", user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _httpClient.PutAsJsonAsync($"api/Users/{user.UserId}", user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Users/{id}");
        }
    }
}
