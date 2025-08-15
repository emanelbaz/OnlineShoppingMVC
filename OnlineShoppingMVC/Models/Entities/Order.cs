namespace OnlineShoppingMVC.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public List<OrderItem> Items { get; set; } = new();
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

    }

}
