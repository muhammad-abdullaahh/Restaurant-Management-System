-- ============================================================
-- LAB 11: DATABASE AUDIT LOGS AND TRIGGERS
-- Bahria University - Karachi Campus
-- ============================================================

USE FoodHeavenDb;
GO

-- ============================================================
-- 1. RESERVATION AUDIT LOGS (AFTER TRIGGER)
-- ============================================================

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ReservationAudit')
BEGIN
    CREATE TABLE ReservationAudit (
        AuditID INT IDENTITY(1,1) PRIMARY KEY,
        ReservationId INT,
        CustomerName VARCHAR(100),
        ActionType VARCHAR(20), -- 'STATUS_CHANGE'
        OldStatus VARCHAR(50),
        NewStatus VARCHAR(50),
        ChangedAt DATETIME DEFAULT GETDATE()
    );
END
GO

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
        SELECT i.Id, i.CustomerName, 'STATUS_CHANGE', d.Status, i.Status
        FROM inserted i
        JOIN deleted d ON i.Id = d.Id;
    END
END
GO


-- ============================================================
-- 2. MENU ITEM SOFT DELETE PROTECTION (INSTEAD OF TRIGGER)
-- ============================================================

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
        Description = m.Description + ' (Archived)'
    FROM MenuItems m
    JOIN deleted d ON m.Id = d.Id;

    INSERT INTO MenuItemAudit (MenuItemId, MenuItemName, ActionType)
    SELECT Id, Name, 'SOFT_DELETE'
    FROM deleted;
END
GO

PRINT 'Lab 11: Reservation and Menu Audit Triggers implemented successfully!';
GO
