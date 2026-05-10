$url = "https://images.unsplash.com/photo-1517248135467-4c7edcad34c4?ixlib=rb-4.0.3&q=85&fm=jpg&crop=entropy&cs=srgb&w=2400"
Write-Host "Downloading 4K About Hero image (Attempt 2)..."
try {
    Invoke-WebRequest -Uri $url -OutFile "about_hero_v3.jpg" -UserAgent "Mozilla/5.0 (Windows NT 10.0; Win64; x64)" -TimeoutSec 20
    Write-Host "Download complete."
}
catch {
    Write-Host "Failed to download image: $_"
}
