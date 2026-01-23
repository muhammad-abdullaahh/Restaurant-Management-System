$url = "https://tse1.mm.bing.net/th?q=Grilled+Tofu+Salad+Bowl&w=800&h=600&c=7&rs=1&p=0"
Write-Host "Downloading Grilled Tofu Salad image..."
try {
    Invoke-WebRequest -Uri $url -OutFile "healthy_tofu_salad.jpg" -UserAgent "Mozilla/5.0 (Windows NT 10.0; Win64; x64)" -TimeoutSec 10
    Write-Host "Download complete."
}
catch {
    Write-Host "Failed to download image."
}
