$url = "https://images.unsplash.com/photo-1556910103-1c02745a30bf?w=1920&q=80"
# Trying another ID if that failed:
$url = "https://images.unsplash.com/photo-1507048331197-7d4defdf73a1?w=1920&q=80" # Dark kitchen

Write-Host "Downloading Process BG..."
try {
    Invoke-WebRequest -Uri $url -OutFile "home_process_bg.jpg" -UserAgent "Mozilla/5.0" -TimeoutSec 10
}
catch {
    Write-Host "Failed."
}
