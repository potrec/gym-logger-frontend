using Azure.Core;
using gym_logger_backend.Data;
using gym_logger_backend.Models.User;
using Microsoft.EntityFrameworkCore;

namespace gym_logger_backend.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> IsEmailUniqueAsync(string email);
        Task<User> IsUserNameUniqueAsync(string userName);
        bool IsPasswordCorrect(string password, User user);
        Task<List<User>> GetUsersAsync();
    }
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> IsEmailUniqueAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<User> IsUserNameUniqueAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }
        public bool IsPasswordCorrect(string password, User user)
        {

            return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        }
        public async Task<List<User>> GetUsersAsync()
        {
            return _context.Users.ToList();
        }
    }
}
