USE FoodHeavenDb;
GO

-- ============================================================
-- INSERT MENU ITEMS 
-- ============================================================
-- (We already ran this before, but keeping this block empty just in case)

-- ============================================================
-- INSERT MOCK ADMINS
-- Password for all is: "admin@123" (BCrypt hash)
-- ============================================================
IF NOT EXISTS(SELECT 1 FROM Admins WHERE Username = 'asad_admin')
BEGIN
    INSERT INTO Admins (Username, Email, PasswordHash, PlainPassword, FullName, IsActive, CreatedAt)
    VALUES 
    ('asad_admin', 'asad.admin@restaurant.com', '$2a$11$91d5rGBi2918g81P/D07nOIy0zR1rR2QJ1l83R3/j2m9W/A74U8pC', 'admin@123', 'Muhammad Asad', 1, GETDATE()),
    ('manager', 'manager@restaurant.com', '$2a$11$91d5rGBi2918g81P/D07nOIy0zR1rR2QJ1l83R3/j2m9W/A74U8pC', 'admin@123', 'Restaurant Manager', 1, GETDATE());
END
GO


-- ============================================================
-- INSERT MOCK USERS
-- Password for all is: "user123!" (BCrypt hash)
-- ============================================================
IF NOT EXISTS(SELECT 1 FROM Users WHERE Username = 'john_customer')
BEGIN
    INSERT INTO Users (Username, Email, PasswordHash, Password, CreatedAt)
    VALUES 
    ('john_customer', 'john@gmail.com', '$2a$11$7N00.aKk.d45sT81kU0gQeaV5k.c3/1gL3r11D25K/P9d1l72n17y', 'user123!', GETDATE()),
    ('sarah_foodie', 'sarah@gmail.com', '$2a$11$7N00.aKk.d45sT81kU0gQeaV5k.c3/1gL3r11D25K/P9d1l72n17y', 'user123!', GETDATE());
END
GO

-- ============================================================
-- INSERT MOCK RESERVATIONS
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM Reservations WHERE CustomerName = 'Sarah Smith' AND TableNumber = 'Table 4')
BEGIN
    INSERT INTO Reservations (CustomerName, PhoneNumber, Email, ReservationDate, ReservationTime, PartySize, TableNumber, ReservationType, Status, CreatedAt)
    VALUES 
    ('Sarah Smith', '555-0192', 'sarah@gmail.com', DATEADD(day, 2, GETDATE()), '18:30:00', 4, 'Table 4', 'Standard', 'Confirmed', GETDATE()),
    ('John Doe', '555-1029', 'john@gmail.com', DATEADD(day, 3, GETDATE()), '19:00:00', 2, 'Premium-1', 'Premium', 'Confirmed', GETDATE());
END
GO

-- ============================================================
-- INSERT MOCK DAILY STATS (So Admin Dashboard has charts)
-- ============================================================
INSERT INTO DailyStats (Date, TotalOrders, TotalRevenue, TotalReservations)
VALUES 
(DATEADD(day, -3, GETDATE()), 12, 450.50, 4),
(DATEADD(day, -2, GETDATE()), 15, 600.00, 6),
(DATEADD(day, -1, GETDATE()), 8, 320.75, 3);
GO

PRINT 'Mock Admins, Users, Reservations, and Stats Added Successfully!'
