using OnlineShoppingMVC.Models.Entities;

namespace OnlineShoppingMVC.Services.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order?> GetByIdAsync(int id, bool includeItems = true);
        Task AddAsync(Order cart);
        Task<List<Order>> GetAllAsync();
        Task AddItemAsync(OrderItem item);
    }
}
