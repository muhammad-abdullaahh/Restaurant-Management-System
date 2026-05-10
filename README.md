# FoodHeaven 🍽️ - Restaurant Management System

![FoodHeaven](https://img.shields.io/badge/FoodHeaven-ASP.NET_Core_8_MVC-f2b90d?style=for-the-badge&logo=dotnet)
![TailwindCSS](https://img.shields.io/badge/Tailwind_CSS-38B2AC?style=for-the-badge&logo=tailwind-css&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

FoodHeaven is a fully-featured, full-stack Restaurant Management System built with **C# ASP.NET Core 8 MVC**. It provides a beautiful, modern, and highly interactive user experience powered by **Tailwind CSS** and **Vanilla JavaScript**, while leveraging the robust capabilities of **Entity Framework Core** and **SQL Server** for backend operations.

## ✨ Key Features
- **User Authentication & Role Management:** Secure Login/Registration using BCrypt password hashing. Dual roles: `Admin` and `User`.
- **Menu & Specials Management:** Browse dynamic menus, filter by categories, and search for items. Admins can manage items (Soft-Delete implemented via DB Triggers).
- **Online Ordering & Cart System:** Fully functional shopping cart with persistent user sessions. Secure checkout and real-time order tracking.
- **Table Reservations:** Book tables dynamically with date/time selection. Audit logs track reservation status changes.
- **Loyalty & Rewards Program:** Integrated points system where users earn and spend points on their orders.
- **Admin Dashboard:** Comprehensive dashboard with daily stats, database logs, and complete CRUD functionality for the system.
- **Modern UI/UX:** Responsive, dark/light mode supported interface using Tailwind CSS and custom animations.

## 🛠️ Tech Stack
**Frontend:**
- HTML5, CSS3, JavaScript (Vanilla ES6+)
- [Tailwind CSS](https://tailwindcss.com/) (via CDN)
- Google Fonts & Material Symbols

**Backend:**
- C# .NET 8.0
- ASP.NET Core MVC Pattern
- Dependency Injection & LINQ

**Database:**
- Microsoft SQL Server
- Entity Framework Core 8.0
- Advanced SQL Features: Triggers (INSTEAD OF, AFTER), Views, Stored Procedures

**Packages:**
- `BCrypt.Net-Next` (Password Hashing)
- `MailKit` (Email Services)
- `Twilio` (SMS Integration)
- `Microsoft.EntityFrameworkCore.SqlServer`

## 🏗️ Architecture Flow
1. **Frontend to Backend:** The browser communicates with the server via standard form submissions and JavaScript `Fetch API` (AJAX) for seamless UI updates (like adding to cart).
2. **Backend to Database:** Controllers pass data to `ApplicationDbContext` (EF Core). LINQ queries are converted to SQL and executed against the database.
3. **Database Level Logic:** Advanced business logic (like audit logging and soft deletes) is handled directly inside the database using **SQL Triggers** to ensure data integrity.

## 🚀 Setup & Installation
### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (or LocalDB)
- Visual Studio 2022 / VS Code

### Steps to Run
1. **Clone the Repository**
   ```bash
   git clone <repo-url>
   cd Restaurant-Management-System
   ```
2. **Database Configuration**
   Update the connection string in `appsettings.json` to point to your local SQL Server instance.
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=FoodHeavenDb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False"
   }
   ```
3. **Run Database Scripts**
   Execute the provided `.sql` files in SQL Server Management Studio (SSMS) in the following order to build the database architecture:
   - `FoodHeavenDb_Setup.sql`
   - `FoodHeavenDb_Views.sql`
   - `FoodHeavenDb_StoredProcedures.sql`
   - `FoodHeavenDb_Project_Triggers.sql`
   - `FoodHeavenDb_SeedUsers.sql`
   - `FoodHeavenDb_SeedData.sql`
   
   *(Alternatively, use EF Core Migrations if configured)*
4. **Build and Run**
   Open the solution in Visual Studio and hit `F5`, or run the following CLI command:
   ```bash
   dotnet build
   dotnet run
   ```
5. **Access the Application**
   Open your browser and navigate to `https://localhost:5001` or the port specified in the console.

## 📚 Documentation
For deeper dives into the project architecture, please refer to the internal documentation:
- `README_FULL_STACK_FLOW.md` - Complete data flow from UI to Database.
- `README_MODULES_TABLES.md` - Module breakdown and Database relationships.
- `README_DATABASE_VIVA.md` - Advanced SQL concepts used in the project.

## 📄 License
This project is licensed under the MIT License.
