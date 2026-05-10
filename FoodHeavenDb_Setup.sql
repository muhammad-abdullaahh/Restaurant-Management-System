-- ============================================================
-- FoodHeaven Restaurant Database Setup Script
-- Run this entire script in SSMS (SQL Server Management Studio)
-- ============================================================

-- Step 1: Create the Database
CREATE DATABASE FoodHeavenDb;
GO

-- Step 2: Switch to the new database
USE FoodHeavenDb;
GO

-- ============================================================
-- TABLE: Admins
-- ============================================================
CREATE TABLE Admins
(
    Id             INT IDENTITY(1,1) PRIMARY KEY,
    Username       VARCHAR(50)      NOT NULL,
    Email          VARCHAR(255)     NOT NULL,
    PasswordHash   NVARCHAR(MAX)    NOT NULL,
    PlainPassword  NVARCHAR(MAX)    NULL,
    FullName       VARCHAR(100)     NOT NULL,
    ProfileImageUrl NVARCHAR(MAX)   NULL,
    IsActive       BIT              NOT NULL DEFAULT 1,
    CreatedAt      DATETIME         NOT NULL DEFAULT GETDATE(),
    LastLoginAt    DATETIME         NULL
);
GO

-- ============================================================
-- TABLE: Users
-- ============================================================
CREATE TABLE Users
(
    Id           INT IDENTITY(1,1) PRIMARY KEY,
    Username     VARCHAR(50)   NOT NULL,
    Email        VARCHAR(255)  NOT NULL,
    PasswordHash NVARCHAR(MAX) NOT NULL,
    Password     NVARCHAR(MAX) NOT NULL DEFAULT '',
    CreatedAt    DATETIME      NOT NULL DEFAULT GETDATE(),
    LastLoginAt  DATETIME      NULL
);
GO

-- ============================================================
-- TABLE: MenuItems
-- ============================================================
CREATE TABLE MenuItems
(
    Id           INT IDENTITY(1,1) PRIMARY KEY,
    Name         VARCHAR(100)  NOT NULL,
    Description  VARCHAR(500)  NOT NULL,
    Price        DECIMAL(10,2) NOT NULL,
    Category     VARCHAR(100)  NOT NULL,
    ImageUrl     NVARCHAR(MAX) NULL,
    Rating       FLOAT         NOT NULL DEFAULT 0,
    ReviewCount  INT           NOT NULL DEFAULT 0,
    IsAvailable  BIT           NOT NULL DEFAULT 1,
    CreatedAt    DATETIME      NOT NULL DEFAULT GETDATE(),
    UpdatedAt    DATETIME      NULL
);
GO

-- ============================================================
-- TABLE: Orders
-- ============================================================
CREATE TABLE Orders
(
    Id                  INT IDENTITY(1,1) PRIMARY KEY,
    OrderNumber         VARCHAR(50)   NOT NULL,
    CustomerName        VARCHAR(200)  NULL,
    CustomerEmail       VARCHAR(255)  NULL,
    CustomerPhone       VARCHAR(50)   NULL,
    Subtotal            DECIMAL(10,2) NOT NULL,
    DeliveryFee         DECIMAL(10,2) NOT NULL,
    Tax                 DECIMAL(10,2) NOT NULL,
    Total               DECIMAL(10,2) NOT NULL,
    Status              VARCHAR(50)   NOT NULL DEFAULT 'Pending',
    PromoCode           VARCHAR(50)   NULL,
    Discount            DECIMAL(10,2) NOT NULL DEFAULT 0,
    SpecialInstructions NVARCHAR(MAX) NULL,
    OrderDate           DATETIME      NOT NULL DEFAULT GETDATE(),
    CompletedDate       DATETIME      NULL,
    DeliveryAddress     NVARCHAR(MAX) NULL,
    PaymentMethod       VARCHAR(100)  NULL,
    UserId              INT           NULL,
    CONSTRAINT FK_Orders_Users FOREIGN KEY (UserId) REFERENCES Users(Id)
);
GO

-- ============================================================
-- TABLE: OrderItems
-- ============================================================
CREATE TABLE OrderItems
(
    Id             INT IDENTITY(1,1) PRIMARY KEY,
    OrderId        INT           NOT NULL,
    MenuItemId     INT           NOT NULL,
    Quantity       INT           NOT NULL,
    Price          DECIMAL(10,2) NOT NULL,
    Customization  NVARCHAR(MAX) NULL,
    CONSTRAINT FK_OrderItems_Orders    FOREIGN KEY (OrderId)    REFERENCES Orders(Id)    ON DELETE CASCADE,
    CONSTRAINT FK_OrderItems_MenuItems FOREIGN KEY (MenuItemId) REFERENCES MenuItems(Id)
);
GO

-- ============================================================
-- TABLE: Reservations
-- ============================================================
CREATE TABLE Reservations
(
    Id               INT IDENTITY(1,1) PRIMARY KEY,
    CustomerName     VARCHAR(100)  NOT NULL,
    PhoneNumber      VARCHAR(50)   NOT NULL,
    Email            VARCHAR(255)  NULL,
    ReservationDate  DATETIME      NOT NULL,
    ReservationTime  TIME          NOT NULL,
    PartySize        INT           NOT NULL,
    TableNumber      VARCHAR(50)   NOT NULL,
    ReservationType  VARCHAR(50)   NOT NULL DEFAULT 'Standard',
    SpecialRequests  NVARCHAR(MAX) NULL,
    Status           VARCHAR(50)   NOT NULL DEFAULT 'Confirmed',
    CreatedAt        DATETIME      NOT NULL DEFAULT GETDATE(),
    UpdatedAt        DATETIME      NULL,
    IsPremiumTable   BIT           NOT NULL DEFAULT 0,
    EstimatedCost    DECIMAL(10,2) NOT NULL DEFAULT 0
);
GO

-- ============================================================
-- TABLE: ContactMessages
-- ============================================================
CREATE TABLE ContactMessages
(
    Id            INT IDENTITY(1,1) PRIMARY KEY,
    FullName      VARCHAR(100)   NOT NULL,
    Email         VARCHAR(255)   NOT NULL,
    PhoneNumber   VARCHAR(50)    NOT NULL,
    Message       NVARCHAR(1000) NOT NULL,
    IsRead        BIT            NOT NULL DEFAULT 0,
    CreatedAt     DATETIME       NOT NULL DEFAULT GETDATE(),
    AdminResponse NVARCHAR(MAX)  NULL,
    RespondedAt   DATETIME       NULL
);
GO

-- ============================================================
-- TABLE: LoyaltyAccounts
-- ============================================================
CREATE TABLE LoyaltyAccounts
(
    Id               INT IDENTITY(1,1) PRIMARY KEY,
    CustomerId       VARCHAR(50)   NOT NULL,
    CustomerName     VARCHAR(100)  NOT NULL,
    Email            VARCHAR(255)  NULL,
    PhoneNumber      VARCHAR(50)   NULL,
    Points           INT           NOT NULL DEFAULT 0,
    MembershipTier   VARCHAR(50)   NOT NULL DEFAULT 'Bronze',
    LunchPunchCount  INT           NOT NULL DEFAULT 0,
    CreatedAt        DATETIME      NOT NULL DEFAULT GETDATE(),
    LastActivityDate DATETIME      NULL
);
GO

-- ============================================================
-- TABLE: LoyaltyTransactions
-- ============================================================
CREATE TABLE LoyaltyTransactions
(
    Id               INT IDENTITY(1,1) PRIMARY KEY,
    LoyaltyAccountId INT           NOT NULL,
    TransactionType  VARCHAR(50)   NOT NULL,
    Points           INT           NOT NULL,
    Description      NVARCHAR(MAX) NULL,
    OrderId          INT           NULL,
    TransactionDate  DATETIME      NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_LoyaltyTransactions_LoyaltyAccounts
        FOREIGN KEY (LoyaltyAccountId) REFERENCES LoyaltyAccounts(Id)
);
GO

-- ============================================================
-- TABLE: Subscribers
-- ============================================================
CREATE TABLE Subscribers
(
    Id           INT IDENTITY(1,1) PRIMARY KEY,
    Email        VARCHAR(255) NOT NULL,
    SubscribedAt DATETIME     NOT NULL DEFAULT GETDATE()
);
GO

-- ============================================================
-- TABLE: DailyStats
-- ============================================================
CREATE TABLE DailyStats
(
    Id                INT IDENTITY(1,1) PRIMARY KEY,
    Date              DATETIME      NOT NULL,
    TotalOrders       INT           NOT NULL DEFAULT 0,
    TotalRevenue      DECIMAL(18,2) NOT NULL DEFAULT 0,
    TotalReservations INT           NOT NULL DEFAULT 0
);
GO


PRINT 'Database and all tables created successfully!';
GO
