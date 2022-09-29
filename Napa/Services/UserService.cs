using Microsoft.EntityFrameworkCore;
using Napa.Data;
using Napa.Models;

namespace Napa.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Users.FirstOrDefaultAsync(n => n.Id == id);
            _context.Users.Remove(result);
            await _context.SaveChangesAsync();
        }

        public Task<List<User>> GetAll()
                => _context.Users.ToListAsync();

        public async Task<User> GetAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
            return user;
        }

        public async Task<(bool IsSuccess, Exception exception)> InsertUserAsync(User login)
        {
            try
            {
                await _context.Users.AddAsync(login);
                await _context.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception e)
            {
                return (false, e);
            }
        }
    }
}
