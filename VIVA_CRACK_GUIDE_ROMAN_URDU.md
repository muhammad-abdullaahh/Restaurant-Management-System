# 🎯 FoodHeaven Project: Viva Crack Guide (Roman Urdu)

Yeh guide aapko Viva mein 100% kamyabi dila sakti hai. Is mein project ka har technical point asaan lafzon mein samjhaya gaya hai.

---

## 1. 🏗️ Project Ka Intro (Introduction)
**Sawal: Yeh project kya hai aur kyun banaya?**
*   **Jawab**: Sir, yeh "FoodHeaven" ek modern **Restaurant Management System** hai. Iska maqsad restaurant ki sales, orders, aur customer reservations ko online manage karna hai. 
*   **Key Features**: Online Ordering, Table Reservation, Loyalty Points (Inam), aur Admin Dashboard.

---

## 2. 💻 Technologies (Tech Stack)
**Sawal: Ismein kaunsi technologies use hui hain?**
*   **Frontend**: HTML5, CSS3 (Tailwind CSS), aur JavaScript.
*   **Backend**: ASP.NET Core MVC (.NET 8).
*   **Database**: Microsoft SQL Server.
*   **ORM**: Entity Framework Core (Database se baat karne ke liye).

---

## 3. 📂 Project ke Khass Modules (Key Modules)
1.  **Menu Module**: Khane ki list dikhata hai (Categories ke saath).
2.  **Order Module**: Shopping cart aur checkout handling.
3.  **Reservation Module**: Table book karne ke liye.
4.  **Loyalty System**: Har order par points milte hain jinse Discount milta hai.
5.  **Admin Portal**: Jahan se menu items aur orders manage hote hain.

---

## 4. 🗄️ Database Logic (Sabsay Important)
Examiner hamesha database par focus karta hai. Aap ye points lazmi batayein:

### A. Joins
Humne `Orders` aur `Users` table ko **JOIN** kiya hai taake order ke saath customer ka naam aur email bhi nazar aaye.

### B. Stored Procedures (SP)
Humne logic database ke andar save kiya hai:
*   `sp_GetPopularMenuItems`: Sab se zyada bikne wali items nikalne ke liye.
*   **Fayda**: SQL code fast chalta hai aur baar baar nahi likhna parta.

### C. Triggers
Humne **Automatic Logs** banaye hain.
*   Jab bhi koi table mein tabdeeli hoti hai, Trigger khud-ba-khud uska "History Record" (Audit) save kar leta hai.

### D. Views
Humne **Virtual Tables** banayi hain:
*   `vw_CategorySalesSummary`: Yeh batata hai ke kis category (Fast Food, Desi) se kitni kamayi hui.

---

## ❓ Common Viva Questions & Answers

**Q1: Entity Framework Core (EF Core) kya hai?**
*   **Ans**: Sir, yeh ek "Bridge" hai jo C# code ko SQL database ke saath jorta hai. Is ki wajah se humein SQL queries likhne ki kam zaroorat parti hai.

**Q2: AppSettings.json file kyun hoti hai?**
*   **Ans**: Is mein database ki **Connection String** aur sensitive settings (jaise Email password) rakhi jati hain.

**Q3: MVC Architecture kya hai?**
*   **Ans**: 
    *   **Model**: Data (Tables).
    *   **View**: Interface (Design).
    *   **Controller**: Logic (Dono ke darmiyan kaam karwane wala).

**Q4: Dependency Injection (DI) kya hai?**
*   **Ans**: `Program.cs` mein hum services (jaise Database context) ko register karte hain taake poray project mein woh asani se use ho saken.

**Q5: Database mein "Foreign Key" ka kya kaam hai?**
*   **Ans**: Yeh do tables ko aapas mein link karti hai. Jaise `Orders` table mein `UserId` aik foreign key hai jo batati hai ke yeh order kis user ka hai.

---

## 🏛️ Part 2: Technical Deep Dive (Mazeed Aham Sawal)

### A. ASP.NET Core & C# Concepts

**Q6: Authentication aur Authorization mein kya farq hai?**
*   **Jawab**: 
    *   **Authentication**: Yeh check karna ke user kaun hai (Login).
    *   **Authorization**: Yeh check karna ke user ko kya karne ki ijazat hai (e.g. Admin hi menu delete kar sakta hai, normal user nahi).
    *   **Project mein**: Humne `[Authorize]` attribute use kiya hai controllers par.

**Q7: Async aur Await kyun use karte hain?**
*   **Jawab**: Taake jab database se data aa raha ho, toh website "Freeze" (hang) na ho jaye. Yeh background mein kaam karta hai aur performance behtar banata hai.

**Q8: ModelState.IsValid kya karta hai?**
*   **Jawab**: Yeh check karta hai ke user ne form mein sahi data bhara hai ya nahi (e.g. Email sahi hai ya nahi, ya koi field khali toh nahi chori).

**Q9: Layout Page (`_Layout.cshtml`) ka kya faida hai?**
*   **Jawab**: Yeh hamari website ka "Master Template" hai. Is mein Header, Footer aur Navbar hote hain jo har page par repeat nahi karne parte. `RenderBody()` us jagah data dikhata hai jahan har page ka apna content hota hai.

**Q10: Dependency Injection (DI) humne kahan use ki?**
*   **Jawab**: `Program.cs` mein humne `ApplicationDbContext` aur `EmailService` ko register kiya. Iska faida yeh hai ke Controller ko khud object nahi banana parta, framework khud supply karta hai.

---

### B. Database & SQL Deep Dive

**Q11: Database Normalization kya hai?**
*   **Jawab**: Data ko asay organize karna ke "Redundancy" (dobara likhna) khatam ho jaye. Jaise humne Customer ka address har order mein likhne ke bajaye `Users` table alag banaya hai.

**Q12: Migration kya hoti hai?**
*   **Jawab**: Jab hum C# mein model banate hain, toh Migration us code ko SQL tables mein tabdeel karti hai (`dotnet ef database update`).

**Q13: Indexing kya hai?**
*   **Jawab**: Database mein searching fast karne ke liye Indexing use hoti hai. Primary Key par automatically index ban jata hai.

**Q14: Stored Procedure aur Function mein kya farq hai?**
*   **Jawab**: Stored Procedure data ko "Update/Insert" bhi kar sakta hai, jabki Function aksar sirf calculation karke result wapas deta hai.

---

### C. UI & UX (Design)

**Q15: Tailwind CSS kyun use ki?**
*   **Jawab**: Yeh "Utility-first" framework hai jis se design bohot fast aur modern banta hai. Humne custom animations aur glassmorphism effects isi se banaye hain.

---

## 🏁 Final Viva Tips:
1.  **Confidence**: Agar sawal na aaye toh kahein "Sir, main is par mazeed parhunga" lekin ghalat jawab na dein.
2.  **Code dikhayen**: Agar poochen "Login kaise ho raha hai?", toh foran `AccountController` khol kar dikha dein.
3.  **Project Ownership**: Kahein "Sir, maine is mein database optimization par zyada focus kiya hai taake system fast chale."

---
**Best of Luck, Asad! Phaar dena Viva! 🚀🔥**
