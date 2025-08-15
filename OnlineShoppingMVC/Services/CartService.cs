using OnlineShoppingMVC.Models.Entities;
using OnlineShoppingMVC.Models.ViewModels;
using OnlineShoppingMVC.Services.Interfaces;

namespace OnlineShoppingMVC.Services
{
    public class CartService
    {
        private readonly CartSessionStorage _storage;
        private readonly IProductRepository _products;
        private readonly IDiscountPolicy _discountPolicy;
        private readonly decimal _minForDiscount = 5000m;

        public CartService(CartSessionStorage storage, IProductRepository products, IDiscountPolicy discountPolicy)
        {
            _storage = storage;
            _products = products;
            _discountPolicy = discountPolicy;
        }

        public async Task AddItemAsync(int productId, int quantity)
        {
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));

            var items = _storage.Load();

            var existing = items.FirstOrDefault(x => x.ProductId == productId);
            if (existing == null)
            {
                var product = await _products.GetByIdAsync(productId) ?? throw new KeyNotFoundException();
                items.Add(new OrderItem
                {
                    ProductId = productId,
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                existing.Quantity += quantity;
            }

            _storage.Save(items);
        }

        public void Remove(int productId)
        {
            var items = _storage.Load();
            var item = items.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                items.Remove(item);
                _storage.Save(items);
            }
        }

        public void Clear()
        {
            _storage.Clear();
        }

        public async Task<CartSummaryVm> GetSummaryAsync()
        {
            var items = _storage.Load();

            foreach (var i in items)
            {
                i.Product ??= await _products.GetByIdAsync(i.ProductId);
            }

            var fakeOrder = new Order { Items = items };
            return _discountPolicy.CalculateSummary(fakeOrder, _minForDiscount);
        }
    }
}
