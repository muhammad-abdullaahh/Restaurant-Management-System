$url = "https://images.unsplash.com/photo-1497034825429-c343d7c6a68f?w=800&q=80"
Write-Host "Downloading Honey..."
try {
    Invoke-WebRequest -Uri $url -OutFile "icecream_honeycomb.jpg" -UserAgent "Mozilla/5.0"
}
catch {
    Write-Host "Failed."
}
