using OnlineShoppingMVC.Models.Entities;
using OnlineShoppingMVC.Models.ViewModels;
using OnlineShoppingMVC.Services.Interfaces;

namespace OnlineShoppingMVC.Services
{
    public class DiscountPolicy : IDiscountPolicy
    {
        public CartSummaryVm CalculateSummary(Order cart, decimal discount)
        {
            var subtotal = cart.Items.Sum(i => i.Product.Price * i.Quantity);
            var applyDiscounts = subtotal >= discount;//true if min 5000

            var items = new List<CartItemVm>();
            decimal discountTotal = 0;

            foreach (var i in cart.Items)
            {
                var itemSubtotal = i.Product.Price * i.Quantity;
                var itemDiscount = applyDiscounts ? itemSubtotal * (i.Product.DiscountPercent / 100m) : 0m;
                var itemTotal = itemSubtotal - itemDiscount;
                discountTotal += itemDiscount;

                items.Add(new CartItemVm(
                    i.ProductId,
                    i.Product.Name,
                    i.Product.Price,
                    i.Product.DiscountPercent,
                    i.Quantity,
                    itemSubtotal,
                    itemDiscount,
                    itemTotal
                ));
            }

            var total = subtotal - discountTotal;
            return new CartSummaryVm(items, subtotal, discountTotal, total, applyDiscounts ? discount : 0m);
        }
    }
}
