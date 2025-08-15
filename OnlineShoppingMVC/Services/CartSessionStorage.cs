using Microsoft.AspNetCore.Http;
using OnlineShoppingMVC.Models.Entities;
using System.Text.Json;

namespace OnlineShoppingMVC.Services
{
    public class CartSessionStorage
    {
        private const string Key = "CART";
        private readonly IHttpContextAccessor _http;

        public CartSessionStorage(IHttpContextAccessor http)
        {
            _http = http;
        }

        public List<OrderItem> Load()
        {
            var json = _http.HttpContext!.Session.GetString(Key);
            return json == null
                ? new List<OrderItem>()
                : JsonSerializer.Deserialize<List<OrderItem>>(json)!;
        }

        public void Save(List<OrderItem> items)
        {
            var json = JsonSerializer.Serialize(items);
            _http.HttpContext!.Session.SetString(Key, json);
        }

        public void Clear()
        {
            Save(new List<OrderItem>());
        }
    }
}
