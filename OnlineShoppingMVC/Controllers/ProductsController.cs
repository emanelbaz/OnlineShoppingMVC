using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingMVC.Data;
using OnlineShoppingMVC.Models;
using OnlineShoppingMVC.Models.Entities;
using OnlineShoppingMVC.Services;
using OnlineShoppingMVC.Services.Interfaces;

namespace OnlineShoppingMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _products;
        private readonly CartService _cart;

        // لأبسّط المثال، هنعتبر cartId = 1 ثابت
        private const int DemoCartId = 1;

        public ProductController(IProductRepository products, CartService cart)
        {
            _products = products;
            _cart = cart;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _products.GetAllAsync();
            return View(items);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            await _cart.AddItemAsync( productId, quantity);
            TempData["msg"] = "Added to cart.";
            return RedirectToAction("Index", "Cart");
        }
    }
}
