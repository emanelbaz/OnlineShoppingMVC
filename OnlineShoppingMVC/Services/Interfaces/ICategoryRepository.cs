using OnlineShoppingMVC.Models.Entities;

namespace OnlineShoppingMVC.Services.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
    }
}
