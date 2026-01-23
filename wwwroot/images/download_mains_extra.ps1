$url = "https://tse1.mm.bing.net/th?q=Beef+Wellington+Slice+Plate&w=800&h=600&c=7&rs=1&p=0"
Write-Host "Downloading Beef Wellington image..."
try {
    Invoke-WebRequest -Uri $url -OutFile "mains_beef_wellington.jpg" -UserAgent "Mozilla/5.0 (Windows NT 10.0; Win64; x64)" -TimeoutSec 10
    Write-Host "Download complete."
}
catch {
    Write-Host "Failed to download image."
}
