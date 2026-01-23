<img width="2070" height="1380" alt="image" src="https://github.com/user-attachments/assets/194f325f-8a37-48aa-bbdd-b8953fb606be" /># Food-Heaven-Restaurant

🍽️ FoodHeaven Premium Restaurant Management System

Experience Culinary Excellence
A modern, full-stack restaurant management platform built with ASP.NET Core MVC, Entity Framework Core, and Tailwind CSS.
📌 About the Project

FoodHeaven is a feature-rich restaurant management system designed to handle both customer-facing experiences and internal restaurant operations in one seamless platform.

It provides:
1. A luxury, responsive UI for customers to explore menus, place orders, and reserve tables.
2. A powerful admin dashboard for staff to manage orders, menus, reservations, users, and analytics.
3. The project focuses on real-world business logic, clean architecture, and scalable design, making it suitable for real restaurant environments.**

🌟 Features

👥 Customer Interface

Premium UI/UX

Dark-mode-first design with smooth animations, glassmorphism effects, and a modern aesthetic.

Dynamic Menu Browsing

Filter food items by category with instant search.

Online Ordering System

Cart management with persistent storage and order history.

Table Reservation System

Real-time booking with party size and special requests.

Live Restaurant Status

Automatically displays Open / Closed based on business hours.

Fully Responsive

Optimized for mobile, tablet, and desktop devices.

🛡️ Admin Dashboard

Mobile-First Dashboard

Designed for tablets and mobile devices used by restaurant staff.

Menu Management

Add, update, delete items, control pricing and availability.

Order Management

Track orders and update status:

Pending → Preparing → Completed


Reservation Management

View and manage upcoming table bookings.

User & Role Management

Manage customers and admin staff.

Analytics & Reports

Daily revenue, order count, and historical insights.

Customer Messages

Handle inquiries submitted through the contact form.

🧠 Business Logic

Restaurant Working Hours Logic

Monday – Friday

🕒 11:00 AM – 02:00 AM (Next Day)

Saturday – Sunday

🕒 11:00 AM – 04:00 AM (Next Day)

The system dynamically calculates and displays the restaurant’s current operational status.

🛠️ Tech Stack

| Layer          | Technology                        |
| -------------- | --------------------------------- |
| Backend        | ASP.NET Core MVC (.NET 8)         |
| ORM            | Entity Framework Core             |
| Database       | SQL Server                        |
| Frontend       | Tailwind CSS + Vanilla JavaScript |
| Authentication | Role-Based Authorization          |
| Security       | BCrypt Password Hashing           |
| Icons          | Google Material Symbols           |

📂 Project Structure (High-Level)

FoodHeaven/
│
├── Controllers/
├── Models/
├── Views/
├── Data/
├── wwwroot/
│   ├── css/
│   ├── js/
│
├── appsettings.json
├── Program.cs
└── README.md



