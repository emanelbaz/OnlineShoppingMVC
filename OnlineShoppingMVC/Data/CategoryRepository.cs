using Microsoft.EntityFrameworkCore;
using OnlineShoppingMVC.Models.Entities;
using OnlineShoppingMVC.Services.Interfaces;

namespace OnlineShoppingMVC.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _db;
        public CategoryRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Category>> GetAllAsync()
            => await _db.Categories.ToListAsync();

        public async Task<Category?> GetByIdAsync(int id)
            => await _db.Categories.FindAsync(id);
    }

}
