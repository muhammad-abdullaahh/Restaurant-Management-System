USE FoodHeavenDb;
GO


CREATE OR ALTER VIEW vw_OrderCustomerDetails AS
SELECT 
    O.OrderNumber, 
    O.OrderDate, 
    O.Total, 
    O.Status,
    U.Username as AccountUsername,
    U.Email as AccountEmail,
    O.DeliveryAddress
FROM Orders O
LEFT JOIN Users U ON O.UserId = U.Id;
GO

-- ============================================================
-- 2. View with GROUP BY (Sales per Category)
-- Shows how much revenue each food category is generating
-- ============================================================
CREATE OR ALTER VIEW vw_CategorySalesSummary AS
SELECT 
    M.Category, 
    COUNT(OI.Id) as ItemsSold, 
    SUM(OI.Price * OI.Quantity) as TotalRevenue
FROM MenuItems M
JOIN OrderItems OI ON M.Id = OI.MenuItemId
GROUP BY M.Category;
GO

-- ============================================================
-- 3. View for Dashboard Stats (Complex JOIN + GROUP BY)
-- Shows summary for each order including total items in that order
-- ============================================================
CREATE OR ALTER VIEW vw_DetailedOrderSummary AS
SELECT 
    O.Id as OrderId,
    O.OrderNumber,
    O.CustomerName,
    COUNT(OI.Id) as TotalDifferentItems,
    SUM(OI.Quantity) as TotalQuantity,
    O.Total as FinalBill,
    O.Status
FROM Orders O
LEFT JOIN OrderItems OI ON O.Id = OI.OrderId
GROUP BY O.Id, O.OrderNumber, O.CustomerName, O.Total, O.Status;
GO

PRINT 'SQL Views created successfully!';
GO
