using Microsoft.EntityFrameworkCore;
using OnlineShoppingMVC.Models.Entities;
using OnlineShoppingMVC.Services.Interfaces;

namespace OnlineShoppingMVC.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _db;
        public OrderRepository(AppDbContext db) => _db = db;

        public async Task<Order?> GetByIdAsync(int id, bool includeItems = true)
        {
            IQueryable<Order> q = _db.Orders;
            if (includeItems)
                q = q.Include(c => c.Items).ThenInclude(i => i.Product);
            return await q.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Order Order) => await _db.Orders.AddAsync(Order);

        public async Task<List<Order>> GetAllAsync()
        {
            IQueryable<Order> q = _db.Orders;
           
            return await q.ToListAsync();
        }

        public async Task AddItemAsync(OrderItem item) => await _db.OrderItems.AddAsync(item);
    }
}
