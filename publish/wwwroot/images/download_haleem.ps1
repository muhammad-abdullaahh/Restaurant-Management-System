$url = "https://tse1.mm.bing.net/th?q=Delicious+Shahi+Haleem+Bowl+Garnish+Naan&w=800&h=600&c=7&rs=1&p=0"
Write-Host "Downloading better Haleem image..."
try {
    Invoke-WebRequest -Uri $url -OutFile "haleem_special.jpg" -UserAgent "Mozilla/5.0 (Windows NT 10.0; Win64; x64)" -TimeoutSec 10
    Write-Host "Download complete."
}
catch {
    Write-Host "Failed to download image."
}
