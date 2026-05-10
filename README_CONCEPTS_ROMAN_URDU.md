# 📝 Database Concepts (Roman Urdu Viva Guide)

Is guide mein asaan Roman Urdu mein samjhaya gaya hai ke **JOIN**, **ERM**, **Stored Procedures**, **Triggers**, aur **Views** kya hote hain taake aap Viva mein asani se jawab de saken.

---

## 1. 🏗️ ERM (Entity Relationship Model) Kya Hai?
**ERM** ka matlab hai aik aisa "Map" ya "Design" jo batata hai ke database ke tables aik doosre se kaise connected hain.

*   **Entity**: Yeh aik table hota hai (jaise `Users` ya `Orders`).
*   **Attribute**: Table ke columns (jaise User ka `Name` ya `Email`).
*   **Relationship**: Tables ke beech ka link (jaise aik User ke bohot saare Orders ho sakte hain).

**Viva Tip**: Jab examiner pooche ke ERM kya hai, toh kahein: *"Sir, yeh database ka structural diagram hota hai jo tables ke darmiyan relationships (links) ko show karta hai."*

---

## 2. 🤝 SQL JOINS Kya Hote Hain?
Jab humein do ya do se zyada tables se data aik saath (combined) chahiye ho, toh hum **JOIN** use karte hain.

### A. Inner Join
Yeh sirf woh data dikhata hai jo dono tables mein **match** karta ho.
*   *Example*: Sirf woh Orders dikhao jin ke Users ka data database mein mojood ho.

### B. Left Join
Yeh Left table ka saara data dikhata hai, bhale hi doosre table mein matching ho ya na ho.
*   *Example*: Saare Users dikhao, bhale hi unho ne koi Order diya ho ya nahi.

---

## 3. 🍴 Humare Project Mein Join Kaise Use Hua?
Humare project mein hum ne **Orders** aur **Users** table ko join kiya hai. 
*   **Kyun?**: Taake Admin Dashboard par jab hum Order dekhen, toh humein sirf `UserId` (number) na dikhe, balki us User ka asli **Name** aur **Email** bhi dikhe.

---

## 💡 Important Viva Questions (Roman Urdu):

*   **Q: Primary Key aur Foreign Key mein kya farq hai?**
    *   **Jawab**: Primary Key table ka unique ID hota hai (jaise Roll Number). Foreign Key doosre table se link karne ke liye use hoti hai.
    *   
*   **Q: Database Normalization kyun karte hain?**
    *   **Jawab**: Taake data repeat na ho aur database ka size faltu na barhe.
    *   
*   **Q: One-to-Many Relationship ki misal (example) dein?**
    *   **Jawab**: Aik Customer (One) bohot saare Orders (Many) de sakta hai. Yeh One-to-Many relationship hai.
  
---

## 4. 🚀 Advanced SQL Concepts

### A. Stored Procedures (SP)
Yeh database mein save kiya gaya SQL code ka ek block hota hai.
*   **Asaan Alfaaz mein**: Jaise hum C# mein function banate hain, wese hi SQL mein Stored Procedure banta hai taake mushkil query ko bar bar na likhna paray, bas procedure ko "Call" kar liya jaye.
*   **Fayda**: Yeh fast hota hai aur database ki security barhata hai.

### B. Triggers
Triggers "Automatic" kaam karte hain.
*   **Asaan Alfaaz mein**: Jab bhi table mein koi naya data aye (INSERT), koi change ho (UPDATE), ya delete ho, toh Trigger khud-ba-khud chalta hai.
*   **Example**: Jab koi Order place ho, toh Trigger khud hi Inventory (stock) mein se items kam kar de.

### C. Views
View aik "Virtual Table" hoti hai.
*   **Asaan Alfaaz mein**: Agar aapke paas aik bohat bari aur mushkil query hai jo 5 tables ko join karti hai, toh aap uska aik "View" bana dete hain. Agli baar aapko puri query likhne ki zaroorat nahi, bas View ko select karein jaise table ko karte hain.

---

## 🛠️ In Concepts ko Project mein kaise shamil karein?

Aap in cheezon ko apne .NET project mein **do (2)** tareeqon se add kar sakte hain:

### 1. Entity Framework (EF) Migrations (Behtareen Tareeqa)
Agar aap chahte hain ke aapka code aur database hamesha sync rahein, toh Migrations use karein.
*   Ek nayi migration banayein: `dotnet ef migrations add AddStoredProcedures`
*   Migration file ke `Up()` method mein SQL code likhein:
    ```csharp
    migrationBuilder.Sql("CREATE PROCEDURE GetActiveUsers AS SELECT * FROM Users WHERE IsActive = 1");
    ```

### 2. Manual SQL (Asaan Tareeqa)
*   Aap SQL Server Management Studio (SSMS) kholein.
*   Apne database par Right-click karke "New Query" karein.
*   Wahan apna Procedure, Trigger ya View ka code likh kar "Execute" kar dein.
*   **Note**: Iska nuksaan yeh hai ke agar aap kisi doosre PC par project chalayeinge toh aapko dobara yeh SQL run karni paregi.

---

## 💡 Important Viva Questions (Part 2):

*   **Q: Trigger aur Stored Procedure mein kya farq hai?**
    *   **Jawab**: Stored Procedure ko humein khud "Call" karna parta hai, jabki Trigger kisi event (jaise Insert/Delete) par "khud" chalta hai.

*   **Q: View ka asli data kahan hota hai?**
    *   **Jawab**: View ka apna koi data nahi hota, yeh sirf original tables ka data "dikhata" hai.

*   **Q: Kya hum Stored Procedure is project mein add kar sakte hain?**
    *   **Jawab**: Ji bilkul! Hum EF Core ke zariye ya direct SQL run karke complex reports ya logs ke liye SP aur Triggers add kar sakte hain.

---
**Best of luck for your Viva! 🎯**
