using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingMVC.Data;
using OnlineShoppingMVC.Models.Entities;
using OnlineShoppingMVC.Services;
using OnlineShoppingMVC.Services.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace OnlineShoppingMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cart;

        public CartController(CartService cart)
        {
            _cart = cart;
        }
        public async Task<IActionResult> Index()
        {
            var vm = await _cart.GetSummaryAsync();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Remove(int productId)
        {
            _cart.Remove(productId);
            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            var vm = await _cart.GetSummaryAsync();
            return View(vm);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CheckoutConfirm(
    [FromServices] IOrderRepository orderRepo,
    [FromServices] IUnitOfWork uow)
        {
            var vm = await _cart.GetSummaryAsync();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = new Order
            {
                OrderDate = DateTime.Now,
                Subtotal = vm.Subtotal,
                Discount = vm.DiscountTotal,
                Total = vm.Total,
                UserId = userId,
                Items = vm.Items.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    ProductName = i.Name,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    LineTotal = i.ItemTotal
                }).ToList()
            };

            await orderRepo.AddAsync(order);
            await uow.SaveChangesAsync();

            _cart.Clear();

            TempData["msg"] = $"Order #{order.Id} Completed!";
            return RedirectToAction("Index", "Product");
        }

    }

}
