-- ============================================================
-- FOODHEAVEN DATABASE AUDIT LOGS AND TRIGGERS
-- Applying AFTER and INSTEAD OF triggers to FoodHeaven Project
-- ============================================================

USE FoodHeavenDb;
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ReservationAudit')
BEGIN
    CREATE TABLE ReservationAudit (
        AuditID INT IDENTITY(1,1) PRIMARY KEY,
        ReservationId INT,
        CustomerName VARCHAR(100),
        ActionType VARCHAR(20), -- 'UPDATE' or 'CANCEL'
        OldStatus VARCHAR(50),
        NewStatus VARCHAR(50),
        ChangedAt DATETIME DEFAULT GETDATE()
    );
END
GO

-- Trigger to track Reservation status changes
IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_Reservation_Audit')
    DROP TRIGGER trg_Reservation_Audit;
GO

CREATE TRIGGER trg_Reservation_Audit
ON Reservations
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF UPDATE(Status)
    BEGIN
        INSERT INTO ReservationAudit (ReservationId, CustomerName, ActionType, OldStatus, NewStatus)
        SELECT 
            i.Id, 
            i.CustomerName, 
            'STATUS_CHANGE', 
            d.Status, 
            i.Status
        FROM inserted i
        JOIN deleted d ON i.Id = d.Id;
    END
END
GO


IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'MenuItemAudit')
BEGIN
    CREATE TABLE MenuItemAudit (
        AuditID INT IDENTITY(1,1) PRIMARY KEY,
        MenuItemId INT,
        MenuItemName VARCHAR(100),
        ActionType VARCHAR(20), -- 'SOFT_DELETE'
        ChangedAt DATETIME DEFAULT GETDATE()
    );
END
GO

IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_MenuItem_SoftDelete')
    DROP TRIGGER trg_MenuItem_SoftDelete;
GO

CREATE TRIGGER trg_MenuItem_SoftDelete
ON MenuItems
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE MenuItems
    SET IsAvailable = 0,
        Description = Description + ' (Archived)'
    WHERE Id IN (SELECT Id FROM deleted);
    
    -- Log the soft delete
    INSERT INTO MenuItemAudit (MenuItemId, MenuItemName, ActionType)
    SELECT Id, Name, 'SOFT_DELETE'
    FROM deleted;

    PRINT 'Item was not deleted. It has been marked as Unavailable (Soft Delete).';
END
GO

IF EXISTS (SELECT * FROM sys.triggers WHERE name = 'trg_Orders_AutoStats')
    DROP TRIGGER trg_Orders_AutoStats;
GO

CREATE TRIGGER trg_Orders_AutoStats
ON Orders
AFTER INSERT
AS
BEGIN
    DECLARE @today DATE = GETDATE();
    
    -- Check if we already have a record for today
    IF EXISTS (SELECT 1 FROM DailyStats WHERE CAST(Date AS DATE) = @today)
    BEGIN
        UPDATE DailyStats
        SET TotalOrders = TotalOrders + (SELECT COUNT(*) FROM inserted),
            TotalRevenue = TotalRevenue + (SELECT SUM(Total) FROM inserted)
        WHERE CAST(Date AS DATE) = @today;
    END
    ELSE
    BEGIN
        INSERT INTO DailyStats (Date, TotalOrders, TotalRevenue, TotalReservations)
        VALUES (GETDATE(), (SELECT COUNT(*) FROM inserted), (SELECT SUM(Total) FROM inserted), 0);
    END
END
GO

PRINT 'Project-specific triggers implemented successfully!';
