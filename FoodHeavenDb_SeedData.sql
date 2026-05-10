USE FoodHeavenDb;
GO

-- Clear existing data if any (optional)
DELETE FROM MenuItems;
-- Reset the ID auto-incrementer back to 1
DBCC CHECKIDENT ('MenuItems', RESEED, 0);
GO

-- ============================================================
-- INSERT MENU ITEMS (DML)
-- ============================================================
INSERT INTO MenuItems (Name, Description, Price, Category, ImageUrl, Rating, ReviewCount, IsAvailable, CreatedAt)
VALUES
-- Starters
('Garlic Bread Supreme', 'Toasted baguette slices topped with rich garlic butter and melted mozzarella cheese.', 5.99, 'Starters', '/images/garlic_bread.jpg', 4.6, 120, 1, GETDATE()),
('Crispy Spring Rolls', 'Crispy golden rolls filled with spiced vegetables, served with a sweet chili dip.', 6.99, 'Starters', 'https://images.unsplash.com/photo-1534422298391-e4f8c172dddb?w=800&q=80', 4.2, 85, 1, GETDATE()),
('Spicy Chicken Wings', 'Juicy chicken wings tossed in our signature spicy buffalo sauce.', 9.99, 'Starters', 'https://images.unsplash.com/photo-1527477396000-e27163b481c2?w=800&q=80', 4.8, 310, 1, GETDATE()),

-- Mains
('Zinger Burger', 'Crispy fried chicken fillet topped with lettuce, mayo, and cheese in a seeded bun.', 11.99, 'Mains', 'https://images.unsplash.com/photo-1568901346375-23c9450c58cd?w=800&q=80', 4.7, 450, 1, GETDATE()),
('Grilled Chicken Steak', 'Juicy grilled chicken breast served with steamed vegetables and mashed potatoes.', 18.99, 'Mains', 'https://images.unsplash.com/photo-1532550907401-a500c9a57435?w=800&q=80', 4.5, 200, 1, GETDATE()),
('Margherita Pizza', 'Classic tomato base topped with fresh mozzarella and basil leaves.', 11.99, 'Mains', 'https://images.unsplash.com/photo-1574071318508-1cdbab80d002?w=800&q=80', 4.3, 150, 1, GETDATE()),
('Spaghetti Carbonara', 'Traditional Italian pasta with pancetta, egg, and parmesan cheese sauce.', 14.99, 'Mains', 'https://images.unsplash.com/photo-1546069901-ba9599a7e63c?w=800&q=80', 4.6, 180, 1, GETDATE()),
('Pan-Seared Salmon', 'Atlantic salmon with lemon butter sauce and grilled asparagus.', 28.00, 'Mains', '/images/platter_seafood.jpg', 4.9, 130, 1, GETDATE()),
('Truffle Risotto', 'Creamy arborio rice with fresh black truffles and parmesan crisp.', 24.00, 'Mains', '/images/truffle_risotto.png', 4.7, 210, 1, GETDATE()),

-- Desi
('Chicken Biryani', 'Aromatic basmati rice cooked with spiced chicken and herbs.', 13.99, 'Desi', '/images/biryani.jpg', 4.8, 550, 1, GETDATE()),
('Mutton Karahi', 'Tender mutton cooked in a wok with tomatoes and spices.', 17.99, 'Desi', '/images/karahi.jpg', 4.7, 340, 1, GETDATE()),
('Butter Chicken', 'Chicken simmered in a creamy butter tomato sauce.', 15.99, 'Desi', '/images/butter_chicken.jpg', 4.9, 600, 1, GETDATE()),

-- BBQ
('Chicken Tikka Leg', 'Succulent chicken leg quarter marinated in spicy yogurt and grilled.', 6.99, 'BBQ', '/images/bbq_tikka_leg.jpg', 4.6, 280, 1, GETDATE()),
('Beef Seekh Kabab', 'Spiced minced beef skewers, grilled to juicy perfection.', 9.99, 'BBQ', '/images/bbq_seekh_beef.jpg', 4.5, 230, 1, GETDATE()),

-- Healthy
('Chicken Caesar Salad', 'Fresh romaine lettuce, croutons, parmesan, and grilled chicken.', 11.99, 'Healthy', 'https://images.unsplash.com/photo-1550304943-4f24f54ddde9?w=800&q=80', 4.4, 90, 1, GETDATE()),
('Quinoa Power Bowl', 'Nutrient-packed quinoa with roasted veggies.', 13.99, 'Healthy', 'https://images.unsplash.com/photo-1512621776951-a57141f2eefd?w=800&q=80', 4.8, 120, 1, GETDATE()),

-- Desserts & Ice Cream 
('Triple Chocolate Cake', 'Decadent chocolate cake layers with fudge frosting.', 6.99, 'Desserts', '/images/choc_cake.jpg', 4.9, 440, 1, GETDATE()),
('Classic Tiramisu', 'Coffee-soaked ladyfingers layered with mascarpone cream.', 7.99, 'Desserts', '/images/tiramisu.jpg', 4.7, 190, 1, GETDATE()),
('Vanilla Bean', 'Made with premium vanilla beans.', 4.99, 'Ice Cream', '/images/ic_vanilla.jpg', 4.3, 110, 1, GETDATE()),

-- Drinks
('Virgin Mojito', 'Alcohol-free mint and lime refreshing cocktail.', 5.99, 'Drinks', '/images/mojito.jpg', 4.5, 300, 1, GETDATE()),
('Classic Coca Cola', 'Ice cold classic cola served with lemon.', 2.50, 'Drinks', '/images/coke.jpg', 4.0, 500, 1, GETDATE());

GO
PRINT 'Menu Items Successfully Inserted!';
