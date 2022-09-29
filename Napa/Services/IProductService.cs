using Napa.Models;

namespace Napa.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();
        Task<Product> GetAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<(bool IsSuccess, Exception Exception)> InsertAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
