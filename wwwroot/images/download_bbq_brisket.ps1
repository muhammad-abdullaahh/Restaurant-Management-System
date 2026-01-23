$url = "https://images.unsplash.com/photo-1548679904-9844878a873f?w=800&q=80"
Write-Host "Downloading Brisket..."
try {
    Invoke-WebRequest -Uri $url -OutFile "bbq_beef_brisket.jpg" -UserAgent "Mozilla/5.0" -TimeoutSec 10
    Write-Host "Done."
}
catch {
    Write-Host "Failed."
}
