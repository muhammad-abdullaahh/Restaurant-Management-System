# 🚀 Quick Start Guide - FoodHeaven

## Step-by-Step Setup (5 Minutes)

### Step 1: Open Terminal
Open PowerShell in the project directory:
```powershell
cd "C:\Users\RB Tech\Desktop\Restaurant Website"
```

### Step 2: Restore Packages
```powershell
dotnet restore
```

### Step 3: Install EF Tools (if not already installed)
```powershell
dotnet tool install --global dotnet-ef
```

### Step 4: Create Database
```powershell
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Step 5: Run the Application
```powershell
dotnet run
```

### Step 6: Open in Browser
Navigate to: **https://localhost:5001**

---

## ✅ What You Get

### Pre-seeded Data
- ✅ 9 Menu Items (Starters, Mains, Desserts, Drinks, Healthy)
- ✅ Admin Account (username: `admin`, password: `Admin@123`)
- ✅ All categories configured

### Available Pages
1. **/** - Home page with featured items
2. **/Menu** - Full menu with category filters
3. **/Order/Cart** - Shopping cart
4. **/Contact** - Contact form
5. **/Reservation/Create** - Table booking
6. **/Loyalty** - Rewards program
7. **/Admin/Login** - Admin panel

---

## 🎯 Quick Test Scenarios

### Test 1: Browse and Add to Cart
1. Go to http://localhost:5001
2. Click on any menu item's "+" button
3. See notification "Item added to cart!"
4. Click cart icon (top right)
5. View your items

### Test 2: Place an Order
1. Add items to cart
2. Go to cart page
3. Try promo code: **SAVE10**
4. Click "Place Order"
5. View confirmation

### Test 3: Admin Panel
1. Go to **/Admin/Login**
2. Login with: `admin` / `Admin@123`
3. View dashboard with stats
4. Add a new menu item
5. Manage orders

---

## 🔧 Troubleshooting

### Issue: "dotnet ef not found"
**Solution:**
```powershell
dotnet tool install --global dotnet-ef
```

### Issue: Database connection error
**Solution:**
```powershell
dotnet ef database drop -f
dotnet ef database update
```

### Issue: Port 5001 in use
**Solution:** The app will automatically use the next available port. Check terminal output for the actual URL.

### Issue: JavaScript not working
**Solution:**
1. Clear browser cache (Ctrl+Shift+Delete)
2. Hard refresh (Ctrl+F5)
3. Check browser console for errors

---

## 📂 File Locations

### Need to modify?
- **Colors/Theme:** `Views/Shared/_Layout.cshtml` (Tailwind config)
- **Cart Logic:** `wwwroot/js/app.js`
- **Database:** `Data/ApplicationDbContext.cs`
- **Menu Items:** Admin Panel or seed data in DbContext
- **Routing:** `Program.cs`

---

## 🎨 Customization Tips

### Change Primary Color
Edit Tailwind config:
```javascript
"primary": "#F2B90D",  // Your color here
```

### Add More Menu Items
Two ways:
1. **Admin Panel:** Login → Dashboard → Add Item
2. **Database Seed:** Edit `ApplicationDbContext.SeedData()`

### Modify Promo Codes
Edit `OrderController.cs`:
```csharp
var validCodes = new Dictionary<string, decimal>
{
    { "YOUR_CODE", 0.25m },  // 25% off
    // Add more codes
};
```

---

## 📱 Mobile Testing

### Test Responsive Design
1. Open Developer Tools (F12)
2. Toggle device toolbar (Ctrl+Shift+M)
3. Test on different screen sizes:
   - iPhone 12/13 (390px)
   - iPad (768px)
   - Desktop (1920px)

---

## 🌐 Deploy to Production

### Option 1: Azure App Service
```powershell
# Publish
dotnet publish -c Release -o ./publish

# Deploy to Azure
az webapp deployment source config-zip
```

### Option 2: IIS
1. Publish to folder
2. Create IIS website
3. Point to publish folder
4. Update connection string

### Option 3: Docker
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0
COPY ./publish /app
WORKDIR /app
ENTRYPOINT ["dotnet", "FoodHeaven.dll"]
```

---

## 📞 Need Help?

### Common Commands
```powershell
# Restore packages
dotnet restore

# Build project
dotnet build

# Run project
dotnet run

# Create migration
dotnet ef migrations add MigrationName

# Update database
dotnet  ef database update

# Drop database
dotnet ef database drop

# List migrations
dotnet ef migrations list
```

### Check .NET Version
```powershell
dotnet --version
```
Should be 8.0 or higher.

---

## ✨ Features Checklist

- [x] Responsive design (mobile + desktop)
- [x] Dark mode support
- [x] Shopping cart with localStorage
- [x] Menu management (CRUD)
- [x] Order system
- [x] Reservation system
- [x] Contact form
- [x] Loyalty program
- [x] Admin authentication
- [x] Promo codes
- [x] Real-time cart updates
- [x] Image support
- [x] Category filtering
- [x] Search functionality (ready to implement)

---

**Enjoy your FoodHeaven restaurant website! 🍽️✨**
