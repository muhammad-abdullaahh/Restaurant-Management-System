using System;
using System.Collections.Generic;

namespace FoodHeaven.Data
{
    public static class MenuData
    {
        public static readonly string[] StarterNames = { "Garlic Bread Supreme", "Crispy Spring Rolls", "Classic Bruschetta", "Spicy Chicken Wings", "Golden Calamari", "Stuffed Mushrooms", "Mozzarella Sticks", "Prawn Cocktail", "Loaded Nachos", "Cheesy Quesadilla", "Chicken Satay" };
        public static readonly string[] StarterImages = {
            "/images/garlic_bread.jpg",
            "https://images.unsplash.com/photo-1534422298391-e4f8c172dddb?w=800&q=80", 
            "https://images.unsplash.com/photo-1506280754576-f6fa8a873550?w=800&q=80",
            "https://images.unsplash.com/photo-1527477396000-e27163b481c2?w=800&q=80",
            "https://images.unsplash.com/photo-1604909052743-94e838986d24?w=800&q=80",
            "/images/starter_stuffed_mushrooms_new.jpg",
            "https://images.unsplash.com/photo-1531749668029-2db88e4276c7?w=800&q=80",
            "https://images.unsplash.com/photo-1625943553852-781c6dd46faa?w=800&q=80",
            "https://images.unsplash.com/photo-1615870216519-2f9fa575fa5c?w=800&q=80",
            "https://images.unsplash.com/photo-1618040996337-56904b7850b9?w=800&q=80",
            "/images/starter_chicken_satay.jpg"
        };
        public static readonly decimal[] StarterPrices = { 5.99m, 6.99m, 7.99m, 9.99m, 11.99m, 8.99m, 7.99m, 10.99m, 9.99m, 8.99m, 9.49m };
        public static readonly string[] StarterDescriptions = {
            "Toasted baguette slices topped with rich garlic butter and melted mozzarella cheese.",
            "Crispy golden rolls filled with spiced vegetables, served with a sweet chili dip.",
            "Grilled artisan bread topped with fresh diced tomatoes, basil, garlic, and olive oil.",
            "Juicy chicken wings tossed in our signature spicy buffalo sauce.",
            "Tender calamari rings, lightly battered and fried to golden perfection, served with tartare sauce.",
            "Fresh button mushrooms filled with herb-infused cream cheese and baked until golden.",
            "Golden-fried breaded mozzarella sticks served with a side of zesty marinara sauce.",
            "Succulent prawns served on a bed of crisp lettuce with our classic tangy cocktail sauce.",
            "Crispy tortilla chips piled high with melted cheese, jalapenos, salsa, and sour cream.",
            "Toasted flour tortilla filled with a blend of melted cheeses and grilled bell peppers.",
            "Grilled marinated chicken skewers served with savory peanut sauce."
        };

        public static readonly string[] MainsNames = { 
            "Zinger Burger", "Grilled Chicken Steak", "Beef Lasagna", "Fish and Chips", "Chicken Tikka Masala", "Spaghetti Carbonara", "BBQ Beef Ribs", "Lamb Chops", "Mushroom Risotto", "Spicy Beef Tacos",
            "Margherita Pizza", "Pepperoni Feast", "BBQ Chicken Pizza", "Hawaiian Delight", "Veggie Supreme Pizza", "Meat Lovers Pizza", "Four Cheese Pizza", "Buffalo Chicken Pizza", "Pesto Chicken Pizza", "Mushroom Truffle Pizza",
            "Classic Cheeseburger", "Bacon Deluxe Burger", "Mushroom Swiss Burger", "Double Patty Smash", "Spicy Jalapeño Burger", "BBQ Onion Ring Burger", "Avocado BLT Burger", "Blue Cheese Burger", "Teriyaki Chicken Burger", "Crispy Fish Burger",
            "Beef Wellington"
        };
        public static readonly string[] MainsImages = {
            "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?w=800&q=80",
            "https://images.unsplash.com/photo-1532550907401-a500c9a57435?w=800&q=80",
            "https://images.unsplash.com/photo-1619895092538-128341789043?w=800&q=80",
            "https://images.unsplash.com/photo-1579954115563-e72bf1381629?w=800&q=80",
            "https://images.unsplash.com/photo-1565557623262-b51c2513a641?w=800&q=80",
            "https://images.unsplash.com/photo-1546069901-ba9599a7e63c?w=800&q=80",
            "https://images.unsplash.com/photo-1555939594-58d7cb561ad1?w=800&q=80",
            "https://images.unsplash.com/photo-1600891964092-4316c288032e?w=800&q=80",
            "https://images.unsplash.com/photo-1476124369491-e7addf5db371?w=800&q=80",
            "https://images.unsplash.com/photo-1551504734-5ee1c4a1479b?w=800&q=80",
            "https://images.unsplash.com/photo-1574071318508-1cdbab80d002?w=800&q=80",
            "https://images.unsplash.com/photo-1628840042765-356cda07504e?w=800&q=80",
            "https://images.unsplash.com/photo-1565299624946-b28f40a0ae38?w=800&q=80",
            "https://images.unsplash.com/photo-1565299585323-38d6b0865b47?w=800&q=80",
            "https://images.unsplash.com/photo-1590947132387-155cc02f3212?w=800&q=80",
            "/images/platter_family_bbq.jpg",
            "https://images.unsplash.com/photo-1573821663912-569905455b1c?w=800&q=80",
            "/images/platter_family_bbq.jpg",
            "https://images.unsplash.com/photo-1604382354936-07c5d9983bd3?w=800&q=80",
            "https://images.unsplash.com/photo-1579751626657-72bc17010498?w=800&q=80",
            "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?w=800&q=80",
            "https://images.unsplash.com/photo-1594212699903-ec8a3eca50f5?w=800&q=80",
            "https://images.unsplash.com/photo-1608767221051-2b9d18f35a2f?w=800&q=80",
            "https://images.unsplash.com/photo-1550547660-d9450f859349?w=800&q=80",
            "https://images.unsplash.com/photo-1553979459-d2229ba7433b?w=800&q=80",
            "https://images.unsplash.com/photo-1586816001966-79b736744398?w=800&q=80",
            "https://images.unsplash.com/photo-1568901346375-23c9450c58cd?w=800&q=80",
            "https://images.unsplash.com/photo-1572802419224-296b0aeee0d9?w=800&q=80",
            "https://images.unsplash.com/photo-1521305916504-4a1121188589?w=800&q=80",
            "https://images.unsplash.com/photo-1549611016-3a70d82b5040?w=800&q=80",
            "/images/mains_beef_wellington.jpg"
        };
        public static readonly decimal[] MainsPrices = { 
            11.99m, 18.99m, 15.99m, 14.99m, 16.99m, 14.99m, 21.99m, 23.99m, 15.99m, 13.99m,
            11.99m, 13.99m, 15.99m, 13.99m, 12.99m, 16.99m, 14.99m, 15.99m, 14.99m, 15.99m,
            10.99m, 12.99m, 12.99m, 14.99m, 12.99m, 13.99m, 13.99m, 12.99m, 12.99m, 11.99m,
            34.99m
        };
        public static readonly string[] MainsDescriptions = {
            "Crispy fried chicken fillet topped with lettuce, mayo, and cheese in a seeded bun.",
            "Juicy grilled chicken breast served with steamed vegetables and mashed potatoes.",
            "Layers of pasta, rich meat sauce, and creamy bechamel, baked with cheese.",
            "Classic battered fish fillet served with thick-cut fries and tartare sauce.",
            "Tender chicken chunks simmered in a creamy, spiced tomato sauce.",
            "Traditional Italian pasta with pancetta, egg, and parmesan cheese sauce.",
            "Slow-cooked beef ribs glazed with our smokey BBQ sauce, served with coleslaw.",
            "Succulent lamb chops marinated in herbs and grilled to tender perfection.",
            "Creamy arborio rice cooked with wild mushrooms, parmesan, and truffle oil.",
            "Soft corn tortillas filled with spicy seasoned beef and fresh pico de gallo.",
            "Classic tomato base topped with fresh mozzarella and basil leaves.",
            "Loaded with spicy pepperoni slices on a rich tomato and cheese base.",
            "Grilled chicken, tangy BBQ sauce, red onions, and cilantro.",
            "Ham and pineapple chunks on a cheesy tomato base.",
            "Loaded with bell peppers, mushrooms, onions, olives, and corn.",
            "A meaty feast with pepperoni, ham, beef, and sausage.",
            "A rich blend of Mozzarella, Parmesan, Cheddar, and Gouda cheeses.",
            "Spicy buffalo chicken, blue cheese drizzle, and celery.",
            "Pesto base topped with grilled chicken, sun-dried tomatoes, and pine nuts.",
            "Earthy mushrooms, truffle oil, and thyme on a creamy white base.",
            "Juicy beef patty with cheddar cheese, lettuce, tomato, and pickles.",
            "Beef patty topped with crispy bacon and melted cheese.",
            "Beef patty topped with sautéed wild mushrooms and swiss cheese.",
            "Two smashed beef patties with double cheese and secret sauce.",
            "Spicy beef patty topped with fresh jalapenos and pepper jack cheese.",
            "Beef patty topped with crispy onion rings and BBQ sauce.",
            "Grilled chicken breast with avocado, bacon, lettuce, and tomato.",
            "Beef patty topped with crumbled blue cheese and caramelized onions.",
            "Chicken patty glazed in teriyaki sauce with grilled pineapple.",
            "Crispy breaded fish fillet with tartare sauce and cheese.",
            "Classic beef filet wrapped in puff pastry with mushroom duxelles."
        };

        public static readonly string[] DessertsNames = { 
            "Triple Chocolate Cake", "New York Cheesecake", "Classic Tiramisu", "Warm Apple Pie", "Fudge Brownie", 
            "Ice Cream Sundae", "Vanilla Panna Cotta", "Assorted Macarons", "Cinnamon Churros", "Fresh Fruit Tart",
            "Creme Brulee", "Red Velvet Cake", "Lemon Meringue Pie", "Banana Split", "Chocolate Mousse",
            "Strawberry Shortcake", "Baklava", "Belgian Waffles", "Chocolate Eclairs", "Mango Sorbet",
            "Molten Lava Cake", "Blueberry Muffin", "Carrot Cake"
        };
        public static readonly string[] DessertsImages = {
            "/images/choc_cake.jpg", "/images/cheesecake.jpg", "/images/tiramisu.jpg", "/images/apple_pie.jpg", "/images/brownie.jpg",
            "/images/sundae.jpg", "/images/panna_cotta.jpg", "/images/macarons.jpg", "/images/churros.jpg", "/images/fruit_tart.jpg",
            "/images/creme_brulee.jpg", "/images/red_velvet.jpg", "/images/lemon_pie.jpg", "/images/banana_split.jpg", "/images/choc_mousse.jpg",
            "/images/strawberry_shortcake.jpg", "/images/baklava.jpg", "/images/waffles.jpg", "/images/eclairs.jpg", "/images/sorbet.jpg",
            "/images/dessert_lava_cake.jpg", "/images/dessert_blueberry_muffin.jpg", "/images/dessert_carrot_cake.jpg"
        };
        public static readonly decimal[] DessertsPrices = { 
            6.99m, 7.99m, 7.99m, 6.99m, 5.99m, 6.99m, 7.99m, 8.99m, 5.99m, 6.99m,
            8.99m, 6.99m, 6.99m, 7.99m, 6.99m, 6.99m, 5.99m, 7.99m, 5.99m, 4.99m,
            8.99m, 3.99m, 6.99m
        };
        public static readonly string[] DessertsDescriptions = {
            "Decadent chocolate cake layers with fudge frosting.",
            "Classic rich and creamy cheesecake with a graham cracker crust.",
            "Coffee-soaked ladyfingers layered with mascarpone cream.",
            "Traditional flaky pie crust filled with spiced baked apples.",
            "Chewy rich chocolate brownie served warm.",
            "Scoops of vanilla ice cream with chocolate sauce and nuts.",
            "Silky Italian cream dessert topped with berry coulis.",
            "Colorful French almond cookies with various fillings.",
            "Fried dough pastries dusted with cinnamon sugar, served with chocolate dip.",
            "Butter pastry shell filled with pastry cream and glazed fruit.",
            "Rich custard topped with a crunchy layer of caramelized sugar.",
            "Soft red cocoa cake with cream cheese frosting.",
            "Tangy lemon curd pie topped with fluffy toasted meringue.",
            "Bananas, ice cream scoops, pineapple, strawberry, and chocolate topping.",
            "Light and airy chocolate foam dessert.",
            "Sponge cake sandwiched with fresh strawberries and whipped cream.",
            "Layers of filo pastry filled with chopped nuts and honey syrup.",
            "Crispy waffles served with maple syrup and melted butter.",
            "Choux pastry filled with cream and topped with chocolate icing.",
            "Refreshing dairy-free frozen dessert made with ripe mangoes.",
            "Rich chocolate cake with a gooey molten center.",
            "Freshly baked muffin bursting with blueberries.",
            "Moist carrot cake with cream cheese frosting."
        };

        public static readonly string[] DrinksNames = { 
            "Classic Coca Cola", "Fresh Orange Juice", "Homemade Lemonade", "Iced Caramel Coffee", "Blue Lagoon Mocktail", 
            "Virgin Mojito", "Berry Blast Smoothie", "Japanese Green Tea", "Double Espresso", "Rich Hot Chocolate",
            "Mango Lassi", "Pina Colada", "Iced Tea", "Cold Brew Coffee", "Mineral Water",
            "Pineapple Juice", "Cranberry Cooler", "Mint Margarita", "Masala Chai", "Apple Juice",
            "Peach Iced Tea", "Ginger Ale", "Sparkling Berry Lemonade"
        };
        public static readonly string[] DrinksImages = {
            "/images/coke.jpg", "/images/orange_juice.jpg", "/images/lemonade.jpg", "/images/iced_coffee.jpg", "/images/drink_blue_lagoon.jpg",
            "/images/mojito.jpg", "/images/berry_smoothie.jpg", "/images/green_tea.jpg", "/images/espresso.jpg", "/images/hot_chocolate.jpg",
            "/images/mango_lassi.jpg", "/images/pina_colada.jpg", "/images/iced_tea.jpg", "/images/cold_brew.jpg", "/images/water_bottle.jpg",
            "/images/pineapple_juice.jpg", "/images/drink_cranberry_cooler.jpg", "/images/mint_margarita.jpg", "/images/masala_chai.jpg", "/images/apple_juice.jpg",
            "/images/drink_peach_tea.jpg", "/images/drink_ginger_ale.jpg", "/images/drink_berry_lemonade.jpg"
        };
        public static readonly decimal[] DrinksPrices = { 
            2.50m, 3.99m, 3.99m, 4.99m, 4.99m, 5.99m, 5.99m, 2.99m, 2.99m, 3.99m,
            4.99m, 5.99m, 3.49m, 4.99m, 2.00m, 3.99m, 3.99m, 5.99m, 2.99m, 3.99m,
            3.99m, 2.99m, 4.49m
        };
        public static readonly string[] DrinksDescriptions = {
            "Ice cold classic cola served with lemon.",
            "Freshly squeezed oranges, no added sugar.",
            "Refreshing lemon and mint cooler.",
            "Cold coffee brewed with caramel syrup and milk.",
            "Vibrant blue curacao mocktail with citrus notes.",
            "Alcohol-free mint and lime refreshing cocktail.",
            "Blend of mixed berries for a vitamin boost.",
            "Traditional Japanese matcha tea served hot.",
            "Concentrated shot of robust coffee.",
            "Rich cocoa drink topped with marshmallows.",
            "Traditional yogurt-based mango drink.",
            "Coconut and pineapple tropical mocktail.",
            "Chilled tea with a hint of lemon.",
            "Slow-steeped coffee poured over ice.",
            "Premium bottled mineral water.",
            "Freshly pressed pineapple juice.",
            "Refreshing cranberry juice drink with a hint of lime.",
            "Blended mint and lime ice drink.",
            "Spiced tea brewed with milk and aromatic spices.",
            "Freshly pressed crisp apple juice.",
            "Refreshing sweet tea with real peach slices.",
            "Classic bubbly ginger soda with a lime twist.",
            "Fizzy lemonade infused with mixed berries."
        };

        public static readonly string[] HealthyNames = { "Chicken Caesar Salad", "Traditional Greek Salad", "Quinoa Power Bowl", "Grilled Atlantic Salmon", "Smashed Avocado Toast", "Seasonal Fruit Salad", "Hearty Vegetable Soup", "Acai Smoothie Bowl", "Steamed Seasonal Veggies", "Grilled Chicken Wrap", "Grilled Tofu Salad" };
        public static readonly string[] HealthyImages = {
            "https://images.unsplash.com/photo-1550304943-4f24f54ddde9?w=800&q=80",
            "https://images.unsplash.com/photo-1540189549336-e6e99c3679fe?w=800&q=80",
            "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?w=800&q=80",
            "https://images.unsplash.com/photo-1560717845-968823efbee1?w=800&q=80", 
            "https://images.unsplash.com/photo-1541519227354-08fa5d50c44d?w=800&q=80", 
            "https://images.unsplash.com/photo-1490474418585-ba9bad8fd0ea?w=800&q=80", 
            "https://images.unsplash.com/photo-1547592180-85f173990554?w=800&q=80", 
            "https://images.unsplash.com/photo-1590301157890-4810ed352733?w=800&q=80",
            "https://images.unsplash.com/photo-1592417817038-d13fd7342605?w=800&q=80",
            "https://images.unsplash.com/photo-1626700051175-6818013e1d4f?w=800&q=80",
            "/images/healthy_tofu_salad.jpg"
        };
        public static readonly decimal[] HealthyPrices = { 11.99m, 12.99m, 13.99m, 17.99m, 9.99m, 7.99m, 6.99m, 10.99m, 8.99m, 10.99m, 11.49m };
        public static readonly string[] HealthyDescriptions = {
            "Fresh romaine lettuce, croutons, parmesan, and grilled chicken.",
            "Cucumber, tomatoes, olives, onions, and feta cheese.",
            "Nutrient-packed quinoa with roasted veggies.",
            "Omega-rich salmon fillet grilled with lemon and herbs.",
            "Crusty bread topped with ripe avocado and seeds.",
            "Bowl of fresh seasonal cut fruits.",
            "Warm wholesome vegetable broth.",
            "Acai berry blend topped with granola and fruit.",
            "Basket of perfectly steamed garden vegetables.",
            "Whole wheat wrap filled with lean chicken and salad.",
            "Marinated grilled tofu served on a bed of mixed greens."
        };

        public static readonly string[] DesiNames = {
            "Chicken Biryani", "Mutton Karahi", "Chicken Tikka", "Beef Seekh Kabab", "Butter Chicken", 
            "Chapli Kabab", "Beef Nihari", "Shahi Haleem", "Palak Paneer", "Daal Makhani", 
            "Garlic Naan", "Chicken Malai Boti", "Lahori Fish Fry", "Mutton Pulao", "Aloo Keema", 
            "Rogan Josh", "Tandoori Chicken", "Samosa Chaat", "Gol Gappay", 
            "Chicken Reshmi Kabab", "Kheer", "Mutton Paya", "Chicken Handi", "Zarda"
        };
        public static readonly string[] DesiImages = {
            "/images/biryani.jpg", "/images/karahi.jpg", "/images/tikka.jpg", "/images/seekh_kabab.jpg", "/images/butter_chicken.jpg", 
            "/images/chapli_kabab.jpg", "/images/nihari.jpg", "/images/haleem_special.jpg", "/images/palak_paneer.jpg", "/images/daal.jpg", 
            "/images/naan.jpg", "/images/malai_boti.jpg", "/images/fish_fry.jpg", "/images/pulao.jpg", "/images/aloo_keema.jpg", 
            "/images/rogan_josh.jpg", "/images/tandoori_chicken.jpg", "/images/samosa_chaat.jpg", "/images/gol_gappa.jpg", "/images/reshmi_kabab.jpg", 
            "/images/kheer.jpg", "/images/paya.jpg", "/images/chicken_handi.jpg", "/images/zarda.jpg"
        };
        public static readonly decimal[] DesiPrices = { 
            13.99m, 17.99m, 11.99m, 13.99m, 15.99m, 13.99m, 14.99m, 11.99m, 12.99m, 9.99m, 
            2.49m, 13.99m, 14.99m, 13.99m, 11.99m, 15.99m, 13.99m, 6.99m, 5.99m, 13.99m, 
            5.99m, 14.99m, 16.99m, 5.99m 
        };
        public static readonly string[] DesiDescriptions = {
            "Aromatic basmati rice cooked with spiced chicken and herbs.",
            "Tender mutton cooked in a wok with tomatoes and spices.",
            "Marinated chicken pieces grilled over charcoal.",
            "Spiced minced beef grilled on skewers.",
            "Chicken simmered in a creamy butter tomato sauce.",
            "Traditional minced beef patty fried with spices.",
            "Slow-cooked beef stew with rich spices.",
            "Rich savory porridge made with lentils and meat.",
            "Cottage cheese cubes cooked in creamy spinach.",
            "Slow-cooked black lentils with butter and cream.",
            "Soft leavened bread brushed with garlic butter.",
            "Creamy chicken cubes marinated in mild spices.",
            "Crispy fried fish coated in gram flour batter.",
            "Rice cooked with mutton stock and mild spices.",
            "Minced meat and potatoes cooked with spices.",
            "Aromatic lamb curry with vibrant red gravy.",
            "Chicken roasted in clay oven with red spices.",
            "Crushed samosas topped with chickpeas and yogurt.",
            "Crispy hollow shells filled with spiced water.",
            "Silky chicken mince skewers seasoned with mild spices.",
            "Traditional rice pudding flavored with cardamom.",
            "Slow-cooked trotters soup, rich in flavor.",
            "Boneless chicken curry rich in cream and coconut.",
            "Sweet saffron rice loaded with nuts."
        };

        public static readonly string[] IceCreamNames = {
            "Vanilla Bean", "Rich Chocolate", "Strawberry Swirl", "Mint Choc Chip", "Cookie Dough",
            "Rocky Road", "Butter Pecan", "Espresso Coffee", "Pistachio", "Neapolitan",
            "Mango Delight", "Raspberry Sorbet", "Cookies and Cream", "Salted Caramel", "Black Cherry",
            "Toasted Coconut", "Rum Raisin", "Birthday Cake", "Matcha Green Tea", "Bubblegum", "Honeycomb Crunch"
        };
        public static readonly string[] IceCreamImages = {
            "/images/ic_vanilla.jpg", "/images/ic_chocolate.jpg", "/images/ic_strawberry.jpg", "/images/ic_mint.jpg", "/images/ic_cookiedough.jpg",
            "/images/ic_rockyroad.jpg", "/images/ic_butterpecan.jpg", "/images/ic_coffee.jpg", "/images/ic_pistachio.jpg", "/images/ic_neapolitan.jpg",
            "/images/ic_mango.jpg", "/images/ic_raspberry.jpg", "/images/ic_cookiesncream.jpg", "/images/ic_saltedcaramel.jpg", "/images/ic_cherry.jpg",
            "/images/ic_coconut.jpg", "/images/ic_rumraisin.jpg", "/images/ic_birthday.jpg", "/images/ic_matcha.jpg", "/images/ic_bubblegum.jpg", "/images/icecream_honeycomb.jpg"
        };
        public static readonly decimal[] IceCreamPrices = {
            4.99m, 4.99m, 4.99m, 4.99m, 5.49m, 5.49m, 5.49m, 4.99m, 5.49m, 5.49m,
            5.49m, 4.99m, 5.49m, 5.49m, 5.49m, 5.49m, 5.49m, 5.49m, 5.49m, 4.99m, 5.99m
        };
        public static readonly string[] IceCreamDescriptions = {
            "Made with premium vanilla beans.",
            "Deep cocoa flavor for chocolate lovers.",
            "Creamy strawberry base with fresh fruit ribbons.",
            "Refreshing mint ice cream with dark chocolate chips.",
            "Vanilla ice cream loaded with cookie dough.",
            "Chocolate ice cream with marshmallows and nuts.",
            "Buttery ice cream with crunchy roasted pecans.",
            "Strong coffee flavor in a creamy base.",
            "Made with real roasted pistachios.",
            "Classic trio of vanilla, chocolate, and strawberry.",
            "Tropical mango flavor for a refreshing treat.",
            "Tangy and sweet dairy-free raspberry sorbet.",
            "Vanilla ice cream packed with crushed cookies.",
            "Sweet caramel ice cream with a hint of sea salt.",
            "Rich cream with sweet black cherry pieces.",
            "Creamy coconut ice cream with toasted flakes.",
            "Classic flavor with rum-soaked raisins.",
            "Cake batter flavor with colorful sprinkles.",
            "Authentic Japanese green tea flavor.",
            "Fun blue bubbly flavor for kids.",
            "Sweet honeycomb shards in creamy vanilla ice cream."
        };

        public static readonly string[] ShakesNames = {
            "Classic Vanilla Shake", "Double Chocolate Shake", "Fresh Strawberry Shake", "Oreo Cookies & Cream", "Salted Caramel Shake",
            "Banana Split Shake", "Mint Choc Chip Shake", "Peanut Butter Cup", "Mango Madness Shake", "Coffee Kick Shake",
            "Blueberry Blast Shake", "Nutella Hazelnut Shake", "Pistachio Shake", "Raspberry Ripple", "Chocolate Malt Shake",
            "Pineapple Coconut", "Cherry Garcia Shake", "Matcha Green Tea", "S'mores Shake", "Bubblegum Shake"
        };
        public static readonly string[] ShakesImages = {
            "/images/sh_vanilla.jpg", "/images/sh_chocolate.jpg", "/images/sh_strawberry.jpg", "/images/sh_oreo.jpg", "/images/sh_caramel.jpg",
            "/images/sh_banana.jpg", "/images/sh_mint.jpg", "/images/sh_peanutbutter.jpg", "/images/sh_mango.jpg", "/images/sh_coffee.jpg",
            "/images/sh_blueberry.jpg", "/images/sh_nutella.jpg", "/images/sh_pistachio.jpg", "/images/sh_raspberry.jpg", "/images/sh_malt.jpg",
            "/images/sh_pineapple.jpg", "/images/sh_cherry.jpg", "/images/sh_matcha.jpg", "/images/sh_smores.jpg", "/images/sh_bubblegum.jpg"
        };
        public static readonly decimal[] ShakesPrices = {
            5.99m, 6.49m, 6.49m, 6.99m, 6.99m, 6.99m, 6.49m, 7.49m, 6.99m, 6.49m,
            6.99m, 7.99m, 7.49m, 6.99m, 6.49m, 6.99m, 6.99m, 7.49m, 7.99m, 6.99m
        };
        public static readonly string[] ShakesDescriptions = {
            "Smooth and creamy vanilla milkshake.",
            "Intense chocolate shake topped with shavings.",
            "Blended with fresh strawberries.",
            "Packed with crushed Oreo cookies.",
            "Sweet and salty caramel perfection.",
            "Banana, chocolate, and strawberry blend.",
            "Refreshing mint shake with chocolate chips.",
            "Rich peanut butter and chocolate blend.",
            "Pure mango bliss in a glass.",
            "Cold brew coffee blended with vanilla ice cream.",
            "Antioxidant-rich blueberry shake.",
            "Hazelnut chocolate spread blended into a shake.",
            "Nutty and creamy pistachio flavor.",
            "Vanilla shake with raspberry ribbons.",
            "Old fashioned malted chocolate shake.",
            "Tropical pina colada style milkshake.",
            "Cherry and mixed chocolate shake.",
            "Green tea milkshake.",
            "Toasted marshmallow and chocolate cracker taste.",
            "Sweet and colorful bubblegum flavor."
        };

        public static readonly string[] BbqNames = { 
            "Chicken Tikka Leg", "Chicken Tikka Breast", "Beef Seekh Kabab", "Chicken Seekh Kabab", "Mutton Seekh Kabab",
            "Malai Boti", "Chicken Boti", "Beef Boti", "Behari Kabab", "Gola Kabab",
            "Reshmi Kabab", "Chapli Kabab", "Lamb Chops", "Mutton Ribs", "Fish Tikka",
            "Paneer Tikka", "Haryali Tikka", "Afghani Kabab", "Grilled Prawns", "Mixed BBQ Platter",
            "Turkish Adana Kabab", "Iranian Chelo Kabab", "Lebanese Shish Tawook", "Tandoori Chicken (Half)", "Tandoori Chicken (Full)",
            "BBQ Chicken Wrap", "Grilled Quail", "Spicy BBQ Wings", "Kasturi Boti", "Kandhari Naan Platter",
            "Peri Peri Chicken", "Galouti Kabab", "Smoked Beef Brisket"
        };
        public static readonly string[] BbqImages = {
            "/images/bbq_tikka_leg.jpg", "/images/bbq_tikka_breast.jpg", "/images/bbq_seekh_beef.jpg", "/images/bbq_seekh_chicken.jpg", "/images/bbq_seekh_mutton.jpg",
            "/images/bbq_malai_boti.jpg", "/images/bbq_chicken_boti.jpg", "/images/bbq_beef_boti.jpg", "/images/bbq_behari_kabab.jpg", "/images/bbq_gola_kabab.jpg",
            "/images/bbq_reshmi_kabab.jpg", "/images/bbq_chapli_kabab.jpg", "/images/bbq_lamb_chops.jpg", "/images/bbq_mutton_ribs.jpg", "/images/bbq_fish_tikka.jpg",
            "/images/bbq_paneer_tikka.jpg", "/images/bbq_haryali_tikka.jpg", "/images/bbq_afghani_kabab.jpg", "/images/bbq_prawns.jpg", "/images/bbq_platter.jpg",
            "/images/bbq_adana_kabab.jpg", "/images/bbq_chelo_kabab.jpg", "/images/bbq_shish_tawook.jpg", "/images/bbq_tandoori_half.jpg", "/images/bbq_tandoori_full.jpg",
            "/images/bbq_wings_wrap.jpg", "/images/bbq_quail.jpg", "/images/bbq_chicken_wings.jpg", "/images/bbq_kasturi_boti.jpg", "/images/bbq_kandhari_naan.jpg",
            "/images/bbq_peri_peri.jpg", "/images/bbq_galouti_kabab.jpg", "/images/bbq_beef_brisket.jpg"
        };
        public static readonly decimal[] BbqPrices = {
            6.99m, 7.49m, 9.99m, 8.99m, 11.99m, 11.99m, 10.99m, 11.99m, 10.99m, 9.99m,
            11.99m, 10.99m, 18.99m, 19.99m, 14.99m, 9.99m, 11.49m, 12.99m, 16.99m, 29.99m,
            13.99m, 14.99m, 12.99m, 9.99m, 18.99m,
            8.99m, 15.99m, 7.99m, 11.99m, 16.99m,
            12.99m, 14.99m, 21.99m
        };
        public static readonly string[] BbqDescriptions = {
            "Succulent chicken leg quarter marinated in spicy yogurt and grilled.",
            "Tender chicken breast piece marinated in traditional spices and grilled.",
            "Spiced minced beef skewers, grilled to juicy perfection.",
            "Minced chicken skewers seasoned with herbs and spices.",
            "Premium minced mutton skewers with aromatic spices.",
            "Boneless chicken chunks marinated in cream and mild spices.",
            "Spicy marinated boneless chicken chunks grilled on skewers.",
            "Tender beef chunks marinated in papaya and spices.",
            "Spicy, melt-in-the-mouth beef strips marinated in traditional spices.",
            "Oval-shaped spicy meatballs grilled and served sizzling.",
            "Silky minced chicken kebob with a hint of cream and coriander.",
            "Flat, round minced beef patty fried with spices.",
            "Juicy lamb chops marinated in yogurt and spices.",
            "Tender mutton ribs glazed with a smokey BBQ marinade.",
            "Chunks of fish marinated in mustard and spices.",
            "Cottage cheese cubes marinated in tikka spices.",
            "Chicken chunks marinated in fresh mint and coriander.",
            "Mildly spiced chicken chunks marinated in cashew paste.",
            "Jumbo prawns marinated in tandoori spices and grilled.",
            "A sharing platter including Tikka, Seekh Kababs, and Boti.",
            "Traditional Turkish minced lamb kebab on skewer.",
            "Persian style kebab served with saffron rice.",
            "Lebanese marinated chicken cubes grilled with garlic.",
            "Half chicken marinated in tandoori spices, roasted in clay oven.",
            "Whole chicken marinated in tandoori spices.",
            "Grilled BBQ chicken strips wrapped in a soft tortilla.",
            "Whole quail marinated in traditional spices and grilled.",
            "Chicken wings tossed in spicy BBQ marinade.",
            "Chicken chunks marinated in aromatic fenugreek.",
            "Large Kandhari Naan topped with sizzling kababs.",
            "Spicy Portuguese style grilled chicken with chili sauce.",
            "Lucknowi delicacy, finely minced lamb that melts in your mouth.",
            "Slow-smoked beef brisket rubbed with secret spices and cooked for 12 hours."
        };

        public static readonly string[] PlatterNames = {
            "Family BBQ Platter", "Seafood Deluxe Platter", "Ultimate Burger Platter", "Desi Feast Platter", "Continental Breakfast",
            "Veggie Delight Platter", "Royal Mutton Platter", "Chinese Combo Platter", "Italian Pasta Platter", "Arabian Mandi Platter",
            "Steamboat Grill Platter", "Tex-Mex Fiesta Platter", "Cheese Lovers Platter", "High Tea Platter", "Midnight Snack Platter",
            "Spicy Lovers Platter", "Kids Party Platter", "Health Nut Platter", "Chef's Special Meat Platter", "Dessert Sampler Platter"
        };
        public static readonly string[] PlatterImages = {
            "/images/platter_family_bbq.jpg", "/images/platter_seafood.jpg", "/images/platter_burger.jpg", "/images/platter_desi.jpg", "/images/platter_breakfast.jpg",
            "/images/platter_veggie.jpg", "/images/platter_royal_mutton.jpg", "/images/platter_chinese.jpg", "/images/platter_italian.jpg", "/images/platter_arabian_mandi.jpg",
            "/images/platter_steamboat.jpg", "/images/platter_texmex.jpg", "/images/platter_cheese.jpg", "/images/platter_hightea.jpg", "/images/platter_midnight.jpg",
            "/images/platter_spicy.jpg", "/images/platter_kids.jpg", "/images/platter_health.jpg", "/images/platter_chef_meat.jpg", "/images/platter_dessert.jpg"
        };
        public static readonly decimal[] PlatterPrices = {
            49.99m, 59.99m, 39.99m, 44.99m, 24.99m,
            29.99m, 69.99m, 34.99m, 39.99m, 54.99m,
            49.99m, 34.99m, 29.99m, 39.99m, 24.99m,
            34.99m, 19.99m, 34.99m, 79.99m, 29.99m
        };
        public static readonly string[] PlatterDescriptions = {
            "A grand feast for the family featuring Seekh Kababs, Chicken Tikka, Beef Ribs, and 4 Naans.",
            "Ocean's best catch including Grilled Fish, Jumbo Prawns, Calamari Rings, and Seasoned Fries.",
            "Three gourmet sliders (Beef, Chicken, Lamb) served with onion rings, cheesy fries, and dips.",
            "A traditional spread of Chicken Biryani, Mutton Karahi, 4 Seekh Kababs, and Roghni Naan.",
            "Complete morning boost with 2 Eggs (any style), Sausages, Baked Beans, Grilled Tomatoes, and Toast.",
            "A vegetarian paradise with Paneer Tikka, Grilled Veggies, Falafel, Hummus, and Pita Bread.",
            "Premium Mutton selection: Mutton Chops, Ribs, Seekh Kabab, served on a bed of Mandi Rice.",
            "Asian favorites combined: Egg Fried Rice, Chicken Chowmein, and Chicken Manchurian.",
            "Italian trio: Beef Lasagna, Spinach Ravioli, and Spaghetti Bolognese with Garlic Bread.",
            "Authentic Arabian experience with Mutton Mandi, Chicken Mandi, and aromatic rice.",
            "Interactive grill experience with Marinated Chicken, Beef, and fresh vegetables.",
            "Mexican fiesta with 2 Tacos, Loaded Nachos, and a Cheese Quesadilla with salsa.",
            "Cheesy goodness: Mozzarella Sticks, Fried Cheese Balls, Jalapeno Poppers, and Cheesy Fries.",
            "Elegant assortment of Finger Sandwiches, Scones with Cream & Jam, and French Pastries.",
            "Late night cravings sorted: 6 Wings, 6 Nuggets, and a large portion of Masala Fries.",
            "For the brave: Hot Wings, Spicy Zinger Burger, and Jalapeno Poppers.",
            "Kids favorite: Mini Chicken Burger, 4 Nuggets, Smiley Fries, and a Juice Box.",
            "Guilt-free meal: Grilled Chicken Breast, Quinoa Salad, Steamed Broccoli, and Avocado.",
            "Chef's meat selection: Ribeye Steak, Lamb Chops, and Grilled Chicken Breast.",
            "Sweet ending: Chocolate Brownie, Scoop of Vanilla Ice Cream, and a slice of Cheesecake."
        };

        public static Dictionary<string, (string[] Names, string[] Images, decimal[] Prices, string[] Descriptions)> GetCategoriesData()
        {
            return new Dictionary<string, (string[] Names, string[] Images, decimal[] Prices, string[] Descriptions)>
            {
                { "Starters", (StarterNames, StarterImages, StarterPrices, StarterDescriptions) },
                { "Mains", (MainsNames, MainsImages, MainsPrices, MainsDescriptions) },
                { "BBQ", (BbqNames, BbqImages, BbqPrices, BbqDescriptions) },
                { "Platters", (PlatterNames, PlatterImages, PlatterPrices, PlatterDescriptions) },
                { "Desserts", (DessertsNames, DessertsImages, DessertsPrices, DessertsDescriptions) },
                { "Ice Cream", (IceCreamNames, IceCreamImages, IceCreamPrices, IceCreamDescriptions) },
                { "Shakes", (ShakesNames, ShakesImages, ShakesPrices, ShakesDescriptions) },
                { "Drinks", (DrinksNames, DrinksImages, DrinksPrices, DrinksDescriptions) },
                { "Healthy", (HealthyNames, HealthyImages, HealthyPrices, HealthyDescriptions) },
                { "Desi", (DesiNames, DesiImages, DesiPrices, DesiDescriptions) }
            };
        }
    }
}
