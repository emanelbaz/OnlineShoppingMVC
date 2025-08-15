
namespace OnlineShoppingMVC.Models.ViewModels
{
    public record CartItemVm(
    int ProductId,
    string Name,
    decimal UnitPrice,
    decimal DiscountPercent,
    int Quantity,
    decimal ItemSubtotal,
    decimal ItemDiscount,
    decimal ItemTotal
);
}
