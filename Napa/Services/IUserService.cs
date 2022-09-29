using Napa.Models;
using Napa.ViewModels;

namespace Napa.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User> GetAsync(int id);
        Task<(bool IsSuccess, Exception exception)> InsertUserAsync(User user);
        Task DeleteAsync(int id);
    }
}
