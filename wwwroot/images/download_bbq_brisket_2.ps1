$url = "https://images.unsplash.com/photo-1529193591184-b1d58069ecdd?w=800&q=80" # Brisket/Meat
Write-Host "Downloading Brisket 2..."
try {
    Invoke-WebRequest -Uri $url -OutFile "bbq_beef_brisket.jpg" -UserAgent "Mozilla/5.0" -TimeoutSec 10
}
catch {
    Write-Host "Failed."
}
