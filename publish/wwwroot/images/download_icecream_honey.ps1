$url = "https://images.unsplash.com/photo-1579954115545-a95591f28dfc?w=800&q=80" # Honey/IceCream
Write-Host "Downloading Honeycomb..."
try {
    Invoke-WebRequest -Uri $url -OutFile "icecream_honeycomb.jpg" -UserAgent "Mozilla/5.0"
    Write-Host "Done."
}
catch {
    Write-Host "Failed."
}
