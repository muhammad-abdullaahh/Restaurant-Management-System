# Gmail SMTP Setup Guide for FoodHeaven

To enable email notifications using Gmail for your reservation system, you need to update the `appsettings.json` file with your credentials. **You cannot use your regular Gmail password due to security reasons.**

## Step 1: Generate an App Password
1.  Go to your [Google Account Settings](https://myaccount.google.com/).
2.  Click on **Security** in the left menu.
3.  Under the "Signing in to Google" section, ensure **2-Step Verification** is turned **ON**. (This is required).
4.  Once 2-Step Verification is on, search for **App passwords** in the search bar at the top or look for it under the 2-Step Verification section.
5.  Click **App passwords**.
6.  Enter a custom name (e.g., `FoodHeavenApp`) and click **Create**.
7.  A 16-character password will be generated. **Copy this password.**

## Step 2: Update Application Settings
1.  Open the file named `appsettings.json` in your project folder.
2.  Locate the `"EmailSettings"` section.
3.  Update the fields as follows:

```json
"EmailSettings": {
  "SmtpServer": "smtp.gmail.com",
  "Port": 587,
  "SenderEmail": "YOUR_ACTUAL_EMAIL@gmail.com",
  "SenderName": "FoodHeaven Reservations",
  "Username": "YOUR_ACTUAL_EMAIL@gmail.com",
  "Password": "PASTE_THE_16_CHAR_APP_PASSWORD_HERE"
}
```

*   Replace `YOUR_ACTUAL_EMAIL@gmail.com` with your real Gmail address.
*   Replace `PASTE_THE_16_CHAR_APP_PASSWORD_HERE` with the password you copied in Step 1 (remove any spaces if copied).

## Step 3: Restart the App
Save the file and restart your application (`dotnet run`) for the changes to take effect.
