$items = @{
    "home_hero_cinema.jpg"    = "Cinematic Gourmet Food Dark Background 4k";
    "home_cat_starters.jpg"   = "Gourmet Appetizers Platter High Res";
    "home_cat_mains.jpg"      = "Steak Dinner Fine Dining Plate";
    "home_cat_desserts.jpg"   = "Fancy Chocolate Dessert Plating";
    "home_testimonial_bg.jpg" = "Blurred Restaurant Atmosphere Warm Lights";
    "home_newsletter_bg.jpg"  = "Fresh Herbs and Spices Dark Wood Table"
}

foreach ($k in $items.Keys) {
    $q = $items[$k]
    $url = "https://tse1.mm.bing.net/th?q=$q&w=1920&h=1080&c=7&rs=1&p=0"
    Write-Host "Downloading $k..."
    try {
        Invoke-WebRequest -Uri $url -OutFile $k -UserAgent "Mozilla/5.0 (Windows NT 10.0; Win64; x64)" -TimeoutSec 10
    }
    catch {
        Write-Host "Failed to download $k"
    }
}
