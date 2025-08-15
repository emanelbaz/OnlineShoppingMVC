using OnlineShoppingMVC.Models.Entities;

namespace OnlineShoppingMVC.Services.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
    }
}
