using BlazorAPI.Data;
using BlazorAPI.IRepo;
using BlazorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Data
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _context;

        public UsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _context.UsersDb
                .FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == passwordHash);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.UsersDb.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.UsersDb.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task AddUserAsync(User user)
        {
            _context.UsersDb.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveUserAsync(int id)
        {
            var user = await _context.UsersDb.FindAsync(id);
            if (user != null)
            {
                _context.UsersDb.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateUserAsync(User user)
        {
            var existingUser = await _context.UsersDb.FindAsync(user.UserId);
            if (existingUser != null)
            {
                existingUser.FullName = user.FullName;
                existingUser.PhoneNumber = user.PhoneNumber;
                existingUser.Address = user.Address;
                existingUser.Email = user.Email;
                existingUser.PasswordHash = user.PasswordHash;
                existingUser.Role = user.Role;

                _context.UsersDb.Update(existingUser);
                await _context.SaveChangesAsync();
            }
        }

    }
}
