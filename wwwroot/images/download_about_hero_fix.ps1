$url = "https://tse1.mm.bing.net/th?q=High+Resolution+Luxury+Dark+Restaurant+Interior+HD&w=1920&h=1080&c=7&rs=1&p=0"
Write-Host "Downloading High-Res About Hero image..."
try {
    Invoke-WebRequest -Uri $url -OutFile "about_hero_v2.jpg" -UserAgent "Mozilla/5.0 (Windows NT 10.0; Win64; x64)" -TimeoutSec 10
    Write-Host "Download complete."
}
catch {
    Write-Host "Failed to download image."
}
