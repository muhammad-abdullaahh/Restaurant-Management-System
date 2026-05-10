$items = @{
    "about_gallery_1.jpg" = "Chef Plating Fine Dining Dish";
    "about_gallery_2.jpg" = "Bartender Pouring Cocktail Action Shot";
    "about_gallery_3.jpg" = "Sizzling Steak on Grill Fire";
    "about_gallery_4.jpg" = "Happy Friends Dining and Laughing Restaurant";
    "about_gallery_5.jpg" = "Fresh Bread Baker Flour Action";
    "about_gallery_6.jpg" = "Wine Glass Toast Cheers"
}

foreach ($k in $items.Keys) {
    $q = $items[$k]
    $url = "https://tse1.mm.bing.net/th?q=$q&w=600&h=600&c=7&rs=1&p=0"
    Write-Host "Downloading $k for $q..."
    try {
        Invoke-WebRequest -Uri $url -OutFile $k -UserAgent "Mozilla/5.0 (Windows NT 10.0; Win64; x64)" -TimeoutSec 10
    }
    catch {
        Write-Host "Failed to download $k"
    }
}
