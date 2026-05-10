$items = @{
  "pizza_party.jpg"          = "Pizza Party Pack with 2 large pizzas chicken wings and salad";
  "date_night.jpg"           = "Romantic date night dinner with risotto and sparkling juice";
  "pasta_party.jpg"          = "Pasta party bundle with multiple pasta dishes and garlic bread";
  "burger_madness.jpg"       = "Burger Madness 3 Classic Cheeseburgers and Masala Fries";
  "family_feast.jpg"         = "Family Feast Bundle Burgers and Pasta";
  "healthy_morning.jpg"      = "Healthy Breakfast Avocado Toast and Berry Smoothie";
  "bbq_lovers.jpg"           = "Mixed BBQ Platter Seekh Kabab and Tikka";
  "seafood_extravaganza.jpg" = "Seafood Platter Grilled Salmon and Prawns";
  "weekend_brunch.jpg"       = "Weekend Brunch Platter with Eggs and Coffee";
  "sweet_tooth.jpg"          = "Dessert Platter Lava Cake and Chocolate Cake";
  "desi_royal_feast.jpg"     = "Desi Feast Biryani and Mutton Karahi"
}

cd "c:\Users\RB Tech\Desktop\Restaurant Website - Copy asad\Restaurant Website - Copy\wwwroot\images\deals"

foreach ($k in $items.Keys) {
  $q = [uri]::EscapeDataString($items[$k])
  $url = "https://tse1.mm.bing.net/th?q=$q&w=800&h=600&c=7&rs=1&p=0"
  Write-Host "Downloading $k for $($items[$k])..."
  try {
    Invoke-WebRequest -Uri $url -OutFile $k -UserAgent "Mozilla/5.0 (Windows NT 10.0; Win64; x64)" -TimeoutSec 15
  }
  catch {
    Write-Host "Failed to download $k"
  }
}
