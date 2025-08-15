using OnlineShoppingMVC.Models.Entities;
using OnlineShoppingMVC.Models.ViewModels;

namespace OnlineShoppingMVC.Services.Interfaces
{
    public interface IDiscountPolicy
    {
        CartSummaryVm CalculateSummary(Order cart, decimal discount);
    }
}
