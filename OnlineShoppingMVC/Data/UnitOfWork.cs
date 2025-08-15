using OnlineShoppingMVC.Services.Interfaces;

namespace OnlineShoppingMVC.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public UnitOfWork(AppDbContext db) => _db = db;
        public Task<int> SaveChangesAsync() => _db.SaveChangesAsync();
    }
}
