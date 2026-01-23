# 🍽️ FoodHeaven - Restaurant Management System

## Overview
**FoodHeaven** is a modern, full-stack restaurant website built with **ASP.NET Core MVC** and **Entity Framework Core**. It features a beautiful, responsive UI with complete backend functionality for menu management, online ordering, table reservations, contact management, and customer loyalty programs.

## ✨ Features

### Customer Features
- 🏠 **Home Page** - Beautiful hero section with featured menu items
- 📖 **Menu System** - Browse and filter menu items by category
- 🛒 **Shopping Cart** - Add items, update quantities, apply promo codes
- 📅 **Table Reservations** - Book tables with date, time, and party size selection
- 📧 **Contact Form** - Send inquiries and special requests
- 🎁 **Loyalty Program** - Earn and redeem points, track punch cards
- 🌙 **Dark Mode** - Toggle between light and dark themes

### Admin Features
- 🔐 **Secure Login** - Cookie-based authentication
- 📊 **Dashboard** - View revenue, pending orders, and stats
- 📝 **Menu Management** - Full CRUD operations for menu items
- 📦 **Order Management** - Track and update order status
- 💬 **Message Management** - View and respond to customer inquiries

## 🛠️ Technology Stack

### Backend
- ASP.NET Core 8.0 MVC
- Entity Framework Core 8.0
- SQL Server (LocalDB)
- BCrypt for password hashing
- Cookie Authentication

### Frontend
- Tailwind CSS
- Vanilla JavaScript
- Google Fonts (Plus Jakarta Sans, Noto Sans)
- Material Symbols Icons
- LocalStorage for cart persistence

## 📋 Prerequisites

- .NET 8.0 SDK or higher
- SQL Server LocalDB (included with Visual Studio)
- Visual Studio 2022 or VS Code
- Modern web browser

## 🚀 Getting Started

### 1. Clone or Download the Project
The project is located at: `C:\Users\RB Tech\Desktop\Restaurant Website`

### 2. Restore NuGet Packages
```powershell
cd "C:\Users\RB Tech\Desktop\Restaurant Website"
dotnet restore
```

### 3. Create the Database
Run Entity Framework migrations to create the database:

```powershell
dotnet ef migrations add InitialCreate
dotnet ef database update
```

**Note:** If you don't have `dotnet ef` tools installed, run:
```powershell
dotnet tool install --global dotnet-ef
```

### 4. Run the Application
```powershell
dotnet run
```

The application will start on `https://localhost:5001` (or the port shown in terminal).

### 5. Access the Admin Panel
- Navigate to: `https://localhost:5001/Admin/Login`
- **Default Credentials:**
  - Username: `admin`
  - Password: `Admin@123`

## 📁 Project Structure

```
FoodHeaven/
├── Controllers/           # MVC Controllers
│   ├── HomeController.cs
│   ├── MenuController.cs
│   ├── OrderController.cs
│   ├── ReservationController.cs
│   ├── ContactController.cs
│   ├── LoyaltyController.cs
│   └── AdminController.cs
├── Data/                  # Database Context
│   └── ApplicationDbContext.cs
├── Models/                # Entity Models
│   ├── MenuItem.cs
│   ├── Order.cs
│   ├── Reservation.cs
│   ├── ContactMessage.cs
│   ├── LoyaltyAccount.cs
│   └── Admin.cs
├── Views/                 # Razor Views
│   ├── Home/
│   ├── Shared/
│   └── _ViewImports.cshtml
├── wwwroot/               # Static Files
│   ├── css/
│   │   └── site.css
│   └── js/
│       └── app.js
├── appsettings.json       # Configuration
├── Program.cs             # App Configuration
└── FoodHeaven.csproj      # Project File
```

## 🗄️ Database Schema

### Tables
1. **MenuItems** - Restaurant menu items
2. **Orders** - Customer orders
3. **OrderItems** - Individual items in orders
4. **Reservations** - Table bookings
5. **ContactMessages** - Customer inquiries
6. **LoyaltyAccounts** - Customer rewards accounts
7. **LoyaltyTransactions** - Points history
8. **Admins** - Admin users

## 🎨 Customization

### Change Database Connection
Edit `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Your Connection String Here"
  }
}
```

### Add Menu Items
- **Via Admin Panel:** Login → Dashboard → Add New Item
- **Via Database:** Seed data in `ApplicationDbContext.cs`

### Modify Colors/Theme
Edit Tailwind config in `Views/Shared/_Layout.cshtml`:
```javascript
colors: {
    "primary": "#F2B90D",  // Change to your brand color
    // ... other colors
}
```

## 🔐 Security Features

- Passwords hashed with BCrypt
- Anti-forgery tokens on forms
- Cookie authentication with configurable expiration
- SQL injection protection via EF Core
- XSS protection with Razor encoding

## 📱 Responsive Design

- Mobile-first approach
- Breakpoints:
  - Mobile: < 768px
  - Tablet: 768px - 1023px
  - Desktop: ≥ 1024px
- Touch-optimized controls
- Smooth animations and transitions

## 🧪 Testing the Features

### Test Cart Functionality
1. Go to Menu page
2. Click "Add" on any item
3. View cart at `/Order/Cart`
4. Update quantities
5. Apply promo code: `SAVE10`, `SAVE20`, or `FIRST15`
6. Place order

### Test Reservations
1. Navigate to `/Reservation/Create`
2. Select date, time, party size
3. Choose table from floor plan
4. Fill in contact details
5. Confirm reservation

### Test Loyalty Program
1. Visit `/Loyalty`
2. View points and rewards
3. Try redeeming rewards (requires sufficient points)

## 🐛 Troubleshooting

### Database Issues
```powershell
# Delete and recreate database
dotnet ef database drop
dotnet ef database update
```

### Port Already in Use
Edit `Properties/launchSettings.json` to change ports.

### JavaScript Not Loading
Clear browser cache and ensure `app.js` is in `wwwroot/js/`

## 📦 NuGet Packages

- Microsoft.EntityFrameworkCore.SqlServer (8.0.0)
- Microsoft.EntityFrameworkCore.Tools (8.0.0)
- Microsoft.AspNetCore.Authentication.Cookies (2.2.0)
- BCrypt.Net-Next (4.0.3)

## 🌟 Future Enhancements

- Payment gateway integration
- Email notifications
- Real-time order tracking
- Customer accounts and authentication
- Reviews and ratings system
- Multi-language support
- Mobile app (React Native/Flutter)

## 📄 License

This project is created for educational and demonstration purposes.

## 👨‍💻 Developer Notes

### API Endpoints

#### Menu
- `GET /Menu/GetMenuItems?category={category}` - Get filtered menu items

#### Orders
- `POST /Order/Create` - Create new order
- `POST /Order/UpdateStatus` - Update order status
- `GET /Order/ApplyPromoCode` - Validate promo code

#### Loyalty
- `POST /Loyalty/RedeemReward` - Redeem points
- `POST /Loyalty/AddPoints` - Add points to account
- `GET /Loyalty/GetHistory` - Get transaction history

#### Admin
- `POST /Admin/AddMenuItem` - Add menu item
- `POST /Admin/UpdateMenuItem` - Update menu item
- `POST /Admin/DeleteMenuItem` - Delete menu item
- `GET /Admin/GetOrders?status={status}` - Get orders by status

## 📞 Support

For issues or questions, please check:
1. Ensure all NuGet packages are restored
2. Verify database is created and seeded
3. Check browser console for JavaScript errors
4. Verify .NET 8 SDK is installed

---

**Built with ❤️ using ASP.NET  Core MVC**
