$url = "https://images.unsplash.com/photo-1557142046-c704a3adf364?w=800&q=80" # Pistachio
Write-Host "Downloading Pistachio..."
try {
    Invoke-WebRequest -Uri $url -OutFile "icecream_pistachio.jpg" -UserAgent "Mozilla/5.0"
    Write-Host "Done."
}
catch {
    Write-Host "Failed."
}
