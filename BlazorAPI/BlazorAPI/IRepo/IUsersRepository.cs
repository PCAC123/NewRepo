using BlazorAPI.Models;

namespace BlazorAPI.IRepo
{
    public interface IUsersRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task AddUserAsync(User users);
        Task RemoveUserAsync(int id);
        Task UpdateUserAsync(User users);
        // 👉 Thêm phương thức đăng nhập
        Task<User?> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    }
}
