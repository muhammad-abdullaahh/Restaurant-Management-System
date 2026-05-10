$url = "https://tse1.mm.bing.net/th?q=Luxury+Restaurant+Interior+Warm+Lighting&w=1200&h=800&c=7&rs=1&p=0"
Write-Host "Downloading About Hero image..."
try {
    Invoke-WebRequest -Uri $url -OutFile "about_hero.jpg" -UserAgent "Mozilla/5.0 (Windows NT 10.0; Win64; x64)" -TimeoutSec 10
    Write-Host "Download complete."
}
catch {
    Write-Host "Failed to download image."
}

$url2 = "https://tse1.mm.bing.net/th?q=Professional+Chef+Plating+Food&w=800&h=600&c=7&rs=1&p=0"
Write-Host "Downloading Chef image..."
try {
    Invoke-WebRequest -Uri $url2 -OutFile "about_chef.jpg" -UserAgent "Mozilla/5.0 (Windows NT 10.0; Win64; x64)" -TimeoutSec 10
    Write-Host "Download complete."
}
catch {
    Write-Host "Failed to download image."
}
