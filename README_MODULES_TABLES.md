# 📊 FoodHeaven Modules & Database Relationships

This guide explains how the project's **Modules (Features)** are mapped to the **Database Tables**.

---

## 1. 📂 Core Project Modules

### A. Authentication & Security
*   **Tables**: `Admins`, `Users`
*   **Logic**: Stores login credentials, hashed passwords, and roles.
*   **Controller**: `AccountController` handles registration and login logic.

### B. Menu & Specials Module
*   **Tables**: `MenuItems`, `Deals`, `MenuItemAudit`
*   **Logic**: Manages the food items. The `MenuItemAudit` table is specifically used to track whenever an item is "soft deleted" via a database trigger.
*   **Controllers**: `MenuController` (User view) and `AdminController` (CRUD operations).

### C. Ordering & Sales Module
*   **Tables**: `Orders`, `OrderItems`, `DailyStats`
*   **Logic**: `Orders` holds the main bill, and `OrderItems` holds the specific food items in that bill. `DailyStats` is updated automatically for reporting.
*   **Relationships**: `Orders` is linked to `Users` (Foreign Key) to know who placed the order.

### D. Reservation Module
*   **Tables**: `Reservations`, `ReservationAudit`
*   **Logic**: Handles table bookings. `ReservationAudit` captures every status change (e.g., from *Confirmed* to *Completed*).
*   **Controller**: `HomeController` (Booking) and `AdminController` (Management).

### E. Engagement & Marketing Module
*   **Tables**: `Subscribers`, `ContactMessages`, `LoyaltyAccounts`, `LoyaltyTransactions`
*   **Logic**: Handles newsletter signups, customer messages, and the reward point system.

---

## 2. 🧬 Table Relationships (Entity Framework)

The database uses **Foreign Keys** to create "Parent-Child" connections:

1.  **Orders & OrderItems (One-to-Many)**: 
    *   One order can have many food items.
    *   If you delete an order, the database uses **CASCADE DELETE** to remove its items automatically.
2.  **Users & Orders (One-to-Many)**: 
    *   One user can place multiple orders over time.
3.  **MenuItems & OrderItems**: 
    *   Links the specific food item details to the order history.
4.  **LoyaltyAccounts & Transactions**: 
    *   Tracks every point earned or spent by a customer.

---

## 3. 🛠️ How Modules Access the Tables
*   **ApplicationDbContext**: This is the central hub. Every module (Controller) asks this class for data.
*   **Dependency Injection**: The server provides the database connection to the controllers whenever they are created.

---

## 💡 Top Viva Question:
*   **Q: What is a Foreign Key?**
    *   *A: It is a column in one table (the child) that links to the Primary Key of another table (the parent). It ensures data integrity.*
*   **Q: Why separate Orders and OrderItems?**
    *   *A: This is called **Database Normalization**. It prevents us from repeating customer data for every single food item they buy.*
*   **Q: How do you handle many-to-many relationships?**
    *   *A: We use a "Junction Table" like `OrderItems` to connect `Orders` and `MenuItems`.*
