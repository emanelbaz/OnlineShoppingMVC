using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingMVC.Services.Interfaces;
using System.Security.Claims;

namespace OnlineShoppingMVC.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orders;

        public OrdersController(IOrderRepository orders)
        {
            _orders = orders;
        }

        public async Task<IActionResult> Index()
        {
            //var list = await _orders.GetAllAsync();
            //return View(list);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var list = await _orders.GetAllAsync();
            var myOrders = list.Where(o => o.UserId == userId).ToList();

            return View(myOrders);
        }

        public async Task<IActionResult> Details(int id)
        {
            var order = await _orders.GetByIdAsync(id);
            if (order == null) return NotFound();
            return View(order);
        }
    }
}
