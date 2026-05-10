$items = @{
    "platter_family_bbq.jpg"    = "Family BBQ Grill Platter";
    "platter_seafood.jpg"       = "Seafood Deluxe Platter";
    "platter_burger.jpg"        = "Ultimate Burger Slider Platter";
    "platter_desi.jpg"          = "Desi Feast Platter Pakistani";
    "platter_breakfast.jpg"     = "Continental Breakfast Platter";
    "platter_veggie.jpg"        = "Vegetarian Grill Platter";
    "platter_royal_mutton.jpg"  = "Royal Mutton Platter";
    "platter_chinese.jpg"       = "Chinese Combo Platter";
    "platter_italian.jpg"       = "Italian Pasta Trio Platter";
    "platter_arabian_mandi.jpg" = "Arabian Mandi Platter";
    "platter_steamboat.jpg"     = "Mixed Grill Meat Platter";
    "platter_texmex.jpg"        = "Tex Mex Fiesta Platter";
    "platter_cheese.jpg"        = "Fried Cheese Appetizer Platter";
    "platter_hightea.jpg"       = "English High Tea Platter";
    "platter_midnight.jpg"      = "Fried Snacks Platter";
    "platter_spicy.jpg"         = "Spicy Food Platter";
    "platter_kids.jpg"          = "Kids Meal Platter";
    "platter_health.jpg"        = "Healthy Grilled Chicken Platter";
    "platter_chef_meat.jpg"     = "Chef Mixed Meat Platter";
    "platter_dessert.jpg"       = "Dessert Sampler Platter"
}

foreach ($k in $items.Keys) {
    $q = $items[$k]
    $url = "https://tse1.mm.bing.net/th?q=$q&w=800&h=600&c=7&rs=1&p=0"
    Write-Host "Downloading $k for $q..."
    try {
        Invoke-WebRequest -Uri $url -OutFile $k -UserAgent "Mozilla/5.0 (Windows NT 10.0; Win64; x64)" -TimeoutSec 10
    }
    catch {
        Write-Host "Failed to download $k"
    }
}
