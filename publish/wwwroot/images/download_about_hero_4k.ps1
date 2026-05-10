# Using a specific high-quality Unsplash ID for a luxury restaurant interior
$url = "https://images.unsplash.com/photo-1550966871-3ed3c47e2ce2?q=80&w=2560&auto=format&fit=crop"
Write-Host "Downloading 4K About Hero image..."
try {
    Invoke-WebRequest -Uri $url -OutFile "about_hero_v3.jpg" -UserAgent "Mozilla/5.0 (Windows NT 10.0; Win64; x64)" -TimeoutSec 20
    Write-Host "Download complete."
}
catch {
    Write-Host "Failed to download image: $_"
}
