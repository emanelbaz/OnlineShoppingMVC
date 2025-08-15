# 🛒 Online Shopping MVC Application

Simple shopping web app built with **ASP.NET Core MVC**, following **Clean Architecture principles**, that demonstrates product listing, cart with discount logic, checkout flow, and user authentication using **ASP.NET Core Identity**.

---

## 📌 Features

- ✅ Product listing with category
- ✅ Session-based shopping cart (add/remove items)
- ✅ Automatic discount logic (applied only when subtotal ≥ 5000 EGP)
- ✅ Checkout and save as **Order + OrderItems**
- ✅ ASP.NET Core Identity (Register / Login / Logout)
- ✅ Orders filtered per logged in user
- ✅ Clean folder structure using "Domain / Application / Infrastructure"
- ✅ Repository & UnitOfWork patterns
- ✅ Centralized Error Handling (ProblemDetails, Middleware)

---

## 🗂️ Project Structure
OnlineShoppingMVC
├── Controllers → MVC controllers
├── Models
│ ├── Entities → Product, Category, Order, OrderItem, ApplicationUser
│ └── ViewModels → CartItemVm, CartSummaryVm, ProductVm..
├── Data → DbContext + EF repositories (ProductRepository, OrderRepository,…)
├── Services
│ ├── CartService → Business logic (add/remove cart items, discount)
│ ├── CartSessionStorage → Session wrapper
│ └── DiscountPolicy → IDiscountPolicy implementation
├── Views → Razor Views
│ ├── Product
│ ├── Cart
│ ├── Orders
│ └── Shared/_Layout.cshtml
└── Areas/Identity → Login, Register, etc (ASP.NET Core identity scaffolding)


---

## ⚙️ Tech Stack

| Technology     | Version             |
|----------------|---------------------|
| ASP.NET Core   | .NET 78 MVC         |
| Database       | SQL Server + EF Core |
| Identity       | ASP.NET Core Identity |
| UI            | Bootstrap 5          |

---

## 🚀 Setup & Run Instructions

1. **Update DB connection** in `appsettings.json`  
2. Run EF Core migrations:

```powershell
Add-Migration Init
Update-Database

Run the project

Open /Identity/Account/Register to create a user

👩‍💻 Default Roles (optional)
Email :test@demo.com
Password:P@ssword1!	

🔐 Authentication Notes

Checkout and CheckoutConfirm actions are decorated with [Authorize]

If user is not logged in → auto redirect to login page

After login → returns back to Checkout

📦 Future Extensions (Optional Ideas)

Admin dashboard for managing Products, Categories, Orders

Pagination / Filtering on Products page

Send email notification after placing an order
