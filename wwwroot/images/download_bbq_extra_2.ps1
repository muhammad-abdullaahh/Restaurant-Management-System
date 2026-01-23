$items = @{
    "bbq_peri_peri.jpg"     = "Peri Peri Grilled Chicken";
    "bbq_galouti_kabab.jpg" = "Galouti Kabab Melt in Mouth"
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
