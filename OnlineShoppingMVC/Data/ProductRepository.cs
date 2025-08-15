using Microsoft.EntityFrameworkCore;
using OnlineShoppingMVC.Models.Entities;
using OnlineShoppingMVC.Services.Interfaces;

namespace OnlineShoppingMVC.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;
        public ProductRepository(AppDbContext db) => _db = db;

        public Task<List<Product>> GetAllAsync() =>
            _db.Products.Where(p => p.IsActive).Include(p=>p.Category).ToListAsync();

        public Task<Product?> GetByIdAsync(int id) =>
            _db.Products.FirstOrDefaultAsync(p => p.Id == id && p.IsActive);
    }
}
