USE FoodHeavenDb;
GO

-- =============================================
-- 1. Get Customer Order History
-- =============================================
CREATE OR ALTER PROCEDURE sp_GetCustomerOrderHistory
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT O.OrderNumber, O.OrderDate, O.Total, O.Status, O.PaymentMethod
    FROM Orders O
    WHERE O.UserId = @UserId
    ORDER BY O.OrderDate DESC;
END;
GO

-- =============================================
-- 2. Get Top 5 Most Popular Menu Items
-- =============================================
CREATE OR ALTER PROCEDURE sp_GetPopularMenuItems
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 5 
        M.Name, 
        M.Category,
        COUNT(OI.Id) as TotalOrders, 
        SUM(OI.Quantity) as TotalQuantitySold,
        SUM(OI.Price * OI.Quantity) as TotalRevenueGenerated
    FROM MenuItems M
    JOIN OrderItems OI ON M.Id = OI.MenuItemId
    GROUP BY M.Name, M.Category
    ORDER BY TotalQuantitySold DESC;
END;
GO

-- =============================================
-- 3. Get Daily Revenue and Orders Report
-- =============================================
CREATE OR ALTER PROCEDURE sp_GetDailyRevenueReport
    @ReportDate DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        @ReportDate as ReportDate,
        COUNT(Id) as TotalOrders, 
        ISNULL(SUM(Total), 0) as TotalRevenue,
        ISNULL(AVG(Total), 0) as AverageOrderValue
    FROM Orders
    WHERE CAST(OrderDate AS DATE) = @ReportDate;
END;
GO

PRINT 'Stored Procedures created successfully!';
GO
