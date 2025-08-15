

namespace OnlineShoppingMVC.Models.ViewModels
{
    public record CartSummaryVm(
    IReadOnlyCollection<CartItemVm> Items,
    decimal Subtotal,
    decimal DiscountTotal,
    decimal Total,
    decimal ThresholdApplied
);
}
