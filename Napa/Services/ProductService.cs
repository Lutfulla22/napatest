using Microsoft.EntityFrameworkCore;
using Napa.Data;
using Napa.Models;

namespace Napa.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Products.FirstOrDefaultAsync(n => n.Id == id);
            _context.Products.Remove(result);
            await _context.SaveChangesAsync();
        }

        public Task<bool> ExistsAsync(int id)
             => _context.Products.AnyAsync(c => c.Id == id);

        public Task<List<Product>> GetAll()
               => _context.Products.ToListAsync();


        public async Task<Product> GetAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
            return product;
        }

        public async Task<(bool IsSuccess, Exception Exception)> InsertAsync(Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
                return (true, null);
            }
            catch(Exception e)
            {
                return (false, e);
            }
        }

        public async Task<Product> UpdateAsync(Product product)
        {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return product;
        }
    }
}
