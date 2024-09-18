using Azure.Core;
using gym_logger_backend.Data;
using gym_logger_backend.Models.User;
using gym_logger_backend.Resources;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace gym_logger_backend.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> IsEmailUniqueAsync(string email);
        Task<User> IsUserNameUniqueAsync(string userName);
        bool IsPasswordCorrect(string password, User user);
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserAsync(int id);
        Task<User> GetAuthUser(ClaimsPrincipal claim);
        Task<User> SaveUserAsync(User user);
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
        public async Task<User> GetUserAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetAuthUser(ClaimsPrincipal claim)
        {
            var userIdClaim = claim.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                return null;
            }

            int userId = int.Parse(userIdClaim.Value);

            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }
        public async Task<User> SaveUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
