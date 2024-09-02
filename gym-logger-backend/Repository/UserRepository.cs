using gym_logger_backend.Data;
using gym_logger_backend.Models.User;
using Microsoft.EntityFrameworkCore;

namespace gym_logger_backend.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
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
    }
}
