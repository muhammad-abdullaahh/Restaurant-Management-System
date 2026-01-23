$items = @{
    "bbq_adana_kabab.jpg"   = "Turkish Adana Kabab";
    "bbq_chelo_kabab.jpg"   = "Iranian Chelo Kabab";
    "bbq_shish_tawook.jpg"  = "Lebanese Shish Tawook";
    "bbq_tandoori_half.jpg" = "Tandoori Chicken Half";
    "bbq_tandoori_full.jpg" = "Tandoori Chicken Full";
    "bbq_wings_wrap.jpg"    = "Chicken BBQ Wrap";
    "bbq_quail.jpg"         = "Grilled Quail BBQ";
    "bbq_chicken_wings.jpg" = "Spicy BBQ Chicken Wings";
    "bbq_kasturi_boti.jpg"  = "Kasturi Chicken Boti";
    "bbq_kandhari_naan.jpg" = "Kandhari Naan with Kabab"
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
