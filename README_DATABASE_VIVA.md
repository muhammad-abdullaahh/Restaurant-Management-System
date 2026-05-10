# 🍽️ FoodHeaven Database Architecture & Logic (Viva Guide)

This document explains how the database is structured, how it connects to the application, and the advanced logic (Triggers, Joins, Audits) used in this project.

---

## 1. 🛠️ The Technology Stack
*   **Database Engine**: SQL Server (LocalDB).
*   **ORM**: Entity Framework Core (EF Core) - *Code First approach*.
*   **Connection Method**: Dependency Injection in ASP.NET Core.

> [!NOTE]
> **Roman Urdu**: *Code First approach* ka matlab hai ke hum pehle C# mein Models (Classes) banate hain aur Entity Framework khud-ba-khud un ke liye SQL mein tables bana deta hai.

---

## 2. 🔗 How the Application Connects to the Database
1.  **The Connection String**: Located in `appsettings.json`. It defines the Server Name, Database Name (`FoodHeavenDb`), and Security settings.
2.  **The DbContext**: Found in `Data/ApplicationDbContext.cs`. This is the "Bridge" between C# and SQL. Every table (like `MenuItems`, `Orders`, `Reservations`) is represented here as a `DbSet`.
3.  **Dependency Injection**: In `Program.cs`, we tell the application to use this DbContext whenever it needs to talk to the database.

> [!NOTE]
> **Roman Urdu**: Database se connect karne ke liye hum `appsettings.json` mein server ka pata (address) likhte hain. Phir `DbContext` aik bridge (pul) ka kaam karta hai jo C# aur SQL ko aapas mein jorta hai.

---

## 3. 🛡️ Advanced Database Logic: Triggers
We use two types of SQL Triggers to automate tasks directly in the database:

### A. AFTER TRIGGER (Reservation Audit)
*   **Table**: `ReservationAudit`
*   **Logic**: Every time a Reservation's status changes (e.g., from *Pending* to *Confirmed*), the database automatically creates a copy of that change in the audit table.
*   **Why?**: This ensures we have a permanent history of what changed, by whom, and when, even if the original record is updated.

> [!TIP]
> **Roman Urdu**: Jab bhi reservation ka status badalta hai, yeh trigger automatically purana aur naya status `ReservationAudit` table mein save kar deta hai taake hamare paas record mojood rahe.

### B. INSTEAD OF TRIGGER (Menu Soft Delete)
*   **Table**: `MenuItems`
*   **Logic**: When an admin clicks "Delete", the database **stops** the deletion. Instead, it updates the `IsAvailable` column to `0` (False).
*   **Why?**: "Soft Deleting" is better for business because we never lose historical data. We just hide the item from the customer.

> [!TIP]
> **Roman Urdu**: Yeh trigger "Hard Delete" (permanently mitana) ko rok deta hai aur sirf item ko "Unavailable" kar deta hai (Soft Delete) taake purana data zaya na ho.

---

## 4. 🤝 SQL Joins & Relationships
The project uses **Foreign Keys** to connect different pieces of information:

*   **Order to User (Many-to-One)**: Many `Orders` can belong to one `User`. We use a **JOIN** in the Admin Dashboard to show the Email/Username next to an order.
*   **Daily Stats**: When a new Order is placed, a trigger updates the `DailyStats` table. This is a form of data synchronization without writing extra C# code.

---

## 5. ⚡ Stored Procedures (Performance)
Stored Procedures are pre-compiled SQL scripts stored on the server.
*   **Advantage**: They are faster than standard queries because the execution plan is saved.
*   **Usage**: We use them for heavy calculations like "Total Revenue by Date" to keep the C# code clean and fast.

---

## 💡 Top 3 Viva Tips:
1.  **Soft Delete**: If asked "Why not just delete the row?", answer: *"To preserve data integrity and historical order records. If we delete a pizza, past orders for that pizza would break."*
2.  **Audit Logs**: If asked "Where is the audit logic?", answer: *"It is in the Database Triggers, which makes it faster and more secure than writing it in C#."*
3.  **EF Core**: If asked "How does C# talk to SQL?", answer: *"Via the ApplicationDbContext, which translates LINQ queries into SQL commands automatically."*
