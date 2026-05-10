$items = @{
  "bbq_tikka_leg.jpg"     = "Chicken Tikka Leg BBQ";
  "bbq_tikka_breast.jpg"  = "Chicken Tikka Breast BBQ";
  "bbq_seekh_beef.jpg"    = "Beef Seekh Kabab BBQ";
  "bbq_seekh_chicken.jpg" = "Chicken Seekh Kabab BBQ";
  "bbq_seekh_mutton.jpg"  = "Mutton Seekh Kabab BBQ";
  "bbq_malai_boti.jpg"    = "Chicken Malai Boti BBQ";
  "bbq_chicken_boti.jpg"  = "Chicken Boti BBQ";
  "bbq_beef_boti.jpg"     = "Beef Boti BBQ";
  "bbq_behari_kabab.jpg"  = "Behari Kabab BBQ";
  "bbq_gola_kabab.jpg"    = "Chicken Gola Kabab";
  "bbq_reshmi_kabab.jpg"  = "Reshmi Kabab BBQ";
  "bbq_chapli_kabab.jpg"  = "Chapli Kabab BBQ";
  "bbq_lamb_chops.jpg"    = "Grilled Lamb Chops BBQ";
  "bbq_mutton_ribs.jpg"   = "Grilled Mutton Ribs BBQ";
  "bbq_fish_tikka.jpg"    = "Fish Tikka BBQ";
  "bbq_paneer_tikka.jpg"  = "Paneer Tikka BBQ";
  "bbq_haryali_tikka.jpg" = "Haryali Chicken Tikka";
  "bbq_afghani_kabab.jpg" = "Afghani Kabab BBQ";
  "bbq_prawns.jpg"        = "Grilled BBQ Prawns";
  "bbq_platter.jpg"       = "Mixed BBQ Grill Platter"
}

foreach ($k in $items.Keys) {
  $q = $items[$k]
  $url = "https://tse1.mm.bing.net/th?q=$q&w=800&h=600&c=7&rs=1&p=0"
  Write-Host "Downloading $k for $q..."
  try {
    Invoke-WebRequest -Uri $url -OutFile $k -UserAgent "Mozilla/5.0 (Windows NT 10.0; Win64; x64)" -TimeoutSec 10
  }
  catch {
    Write-Host "Failed to download $k"
  }
}
