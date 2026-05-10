-- SQL Script to fix missing images for Deals and MenuItems
USE FoodHeavenDb;
GO

-- 1. Fix Deals Table
UPDATE Deals SET ImageUrl = '/images/deals/family_feast.jpg' WHERE Title = 'Family Feast Bundle';
UPDATE Deals SET ImageUrl = '/images/deals/date_night.jpg' WHERE Title = 'Date Night Special';
UPDATE Deals SET ImageUrl = '/images/deals/healthy_morning.jpg' WHERE Title = 'Healthy Morning Kick';
UPDATE Deals SET ImageUrl = '/images/deals/bbq_lovers.jpg' WHERE Title = 'BBQ Lovers Platter';
UPDATE Deals SET ImageUrl = '/images/deals/seafood_extravaganza.jpg' WHERE Title = 'Seafood Extravaganza';
UPDATE Deals SET ImageUrl = '/images/deals/weekend_brunch.jpg' WHERE Title = 'Weekend Brunch for Two';
UPDATE Deals SET ImageUrl = '/images/deals/pasta_party.jpg' WHERE Title = 'Pasta Party Bundle';
UPDATE Deals SET ImageUrl = '/images/deals/burger_madness.jpg' WHERE Title = 'Burger Madness';
UPDATE Deals SET ImageUrl = '/images/deals/sweet_tooth.jpg' WHERE Title = 'Sweet Tooth Combo';
UPDATE Deals SET ImageUrl = '/images/deals/desi_royal_feast.jpg' WHERE Title = 'Desi Royal Feast';
UPDATE Deals SET ImageUrl = '/images/deals/pizza_party.jpg' WHERE Title = 'Pizza Party Pack';

-- 2. Fix MenuItems Table (matching by name)
UPDATE MenuItems SET ImageUrl = '/images/deals/family_feast.jpg' WHERE Name = 'Family Feast Bundle';
UPDATE MenuItems SET ImageUrl = '/images/deals/date_night.jpg' WHERE Name = 'Date Night Special';
UPDATE MenuItems SET ImageUrl = '/images/deals/healthy_morning.jpg' WHERE Name = 'Healthy Morning Kick';
UPDATE MenuItems SET ImageUrl = '/images/deals/bbq_lovers.jpg' WHERE Name = 'BBQ Lovers Platter';
UPDATE MenuItems SET ImageUrl = '/images/deals/seafood_extravaganza.jpg' WHERE Name = 'Seafood Extravaganza';
UPDATE MenuItems SET ImageUrl = '/images/deals/weekend_brunch.jpg' WHERE Name = 'Weekend Brunch for Two';
UPDATE MenuItems SET ImageUrl = '/images/deals/pasta_party.jpg' WHERE Name = 'Pasta Party Bundle';
UPDATE MenuItems SET ImageUrl = '/images/deals/burger_madness.jpg' WHERE Name = 'Burger Madness';
UPDATE MenuItems SET ImageUrl = '/images/deals/sweet_tooth.jpg' WHERE Name = 'Sweet Tooth Combo';
UPDATE MenuItems SET ImageUrl = '/images/deals/desi_royal_feast.jpg' WHERE Name = 'Desi Royal Feast';
UPDATE MenuItems SET ImageUrl = '/images/deals/pizza_party.jpg' WHERE Name = 'Pizza Party Pack';

PRINT 'All Deal images fixed successfully using local assets.';
