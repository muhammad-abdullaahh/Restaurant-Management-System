# 🚀 FoodHeaven Full-Stack Data Flow (Viva Guide)

This guide explains how the **Frontend**, **Backend**, and **Database** work together in this project. This is a very common topic for Viva exams!

---

## 1. 🌐 Frontend to Backend Connection
**"How does the browser talk to the server?"**

*   **Technology**: JavaScript **Fetch API** (AJAX).
*   **The Process**: 
    1.  When you click a button (like "Refresh Logs" or "Delete Item") in `Dashboard.cshtml`, a JavaScript function is triggered.
    2.  This function sends a **Request** to a specific URL (Endpoint) on the server, such as `/Admin/GetDatabaseLogsData`.
    3.  The server processes the request and sends back a **JSON Response** (data in a text format).
    4.  The Frontend receives this JSON and updates the HTML tables without refreshing the whole page.

---

## 2. ⚙️ Backend to Database Connection
**"How does C# talk to SQL Server?"**

*   **Technology**: **Entity Framework Core (EF Core)**.
*   **The Process**:
    1.  The Backend uses a "Bridge" class called `ApplicationDbContext`.
    2.  Instead of writing complex SQL queries manually, we use **LINQ** in C#. 
    3.  Example: `_context.MenuItems.ToListAsync()` tells EF Core to generate the SQL command `SELECT * FROM MenuItems` and run it against the database.
    4.  The Database sends the raw rows back, and EF Core converts them into **C# Objects** (like a `List<MenuItem>`) for us to use.

---

## 3. 🛡️ Database Logic (Triggers)
**"How does the Database protect itself?"**

*   **Technology**: **SQL Triggers**.
*   **The Process**:
    1.  Sometimes, logic happens **entirely inside the database** without C# knowing.
    2.  **INSTEAD OF Trigger**: When C# says "Delete this row", the Database intercepts it and says "No, I will just mark it as Unavailable and log it instead."
    3.  **AFTER Trigger**: When a status is updated, the Database says "Okay, I updated it, and now I will also save a copy of this change into the Audit table."

---

## 🔄 The "Big Picture" Flow (Example: Deleting an Item)
1.  **Frontend**: User clicks "Delete" on a Pizza. JavaScript sends a `POST` request to the server.
2.  **Backend**: The `AdminController` receives the request. It tells the `DbContext` to remove that Pizza.
3.  **Database**: The `INSTEAD OF DELETE` trigger fires. It updates the Pizza's status and adds a record to the `MenuItemAudit` table.
4.  **Backend**: Sends a "Success" message back to the browser.
5.  **Frontend**: JavaScript sees the success, re-loads the menu list, and the Pizza now shows as "Archived" or disappears from the active list.

---

## 💡 Top Viva Questions:
*   **Q: Can the Frontend talk directly to the Database?**
    *   *A: No. For security reasons, the Frontend must always go through the Backend (API/Controllers). The Backend acts as a gatekeeper.*
*   **Q: What is JSON?**
    *   *A: It is a lightweight data format used to transport data between the Server and the Browser.*
*   **Q: Why use Triggers instead of C# for logging?**
    *   *A: Triggers are more reliable because they capture changes even if they come from outside the app (like someone manually editing the DB in SSMS).*
