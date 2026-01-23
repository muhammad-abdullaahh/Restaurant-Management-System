$base = "https://images.unsplash.com/photo-"
$items = @{
    "home_gallery_1.jpg"  = "${base}1517248135467-4c7edcad34c4?w=800&q=80"; # Interior
    "home_gallery_2.jpg"  = "${base}1559339352-11d035aa65de?w=800&q=80"; # Drink
    "home_gallery_3.jpg"  = "${base}1540189549336-e6e99c3679fe?w=800&q=80"; # Salad
    "home_gallery_4.jpg"  = "${base}1565299624946-b28f40a0ae38?w=800&q=80"; # Pizza
    "home_gallery_5.jpg"  = "${base}1565958011703-44f9829ba187?w=800&q=80"; # Cake
    "home_gallery_6.jpg"  = "${base}1414235077428-338989a2e8c0?w=800&q=80"; # Plating
    "home_process_bg.jpg" = "${base}1556910103-1c02745a30bf?w=1920&q=80" # Kitchen dark
}

foreach ($k in $items.Keys) {
    $url = $items[$k]
    Write-Host "Downloading $k..."
    try {
        Invoke-WebRequest -Uri $url -OutFile $k -UserAgent "Mozilla/5.0" -TimeoutSec 10
    }
    catch {
        Write-Host "Failed to download $k"
    }
}
