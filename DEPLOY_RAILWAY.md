# 🚂 Deploying FoodHeaven to Railway

Follow these steps to deploy your application to Railway.app with a persistent PostgreSQL database.

## 1. Prerequisites
- A GitHub account.
- A [Railway.app](https://railway.app/) account (Sign up with GitHub).

## 2. Create the Project
1. Go to your **Railway Dashboard**.
2. Click **"New Project"**.
3. Select **"Deploy from GitHub repo"**.
4. Choose your repository: `Food-Heaven-Restaurant`.
5. Click **"Deploy Now"**.

## 3. Add a Database (PostgreSQL)
*Required for persistent data. If you skip this, the app uses SQLite, and data resets on restart.*

1. Once the deployment starts, click on your project card to open the **Project View**.
2. Right-click on the empty canvas or click the **"New"** button.
3. Select **"Database"** -> **"PostgreSQL"**.
4. Wait a moment for the database to initialize.

## 4. Connect the App to the Database
Railway makes this easy!

1. Railway automatically creates a `DATABASE_URL` environment variable for the PostgreSQL service.
2. We just need to make sure your App service can see it.
3. **However**, in a single project, Railway *usually* injects this automatically if you link them.
    - Click on your **App Service** (FoodHeaven-Restaurant).
    - Go to the **"Variables"** tab.
    - If you don't see `DATABASE_URL`, we need to add it:
        1. Click **"New Variable"**.
        2. Name: `DATABASE_URL`.
        3. Value: Type `$` and select `${Postgres.DATABASE_URL}` from the autocomplete dropdown.
        4. Click **Add**.

## 5. Generate a Public Domain
1. Click on your **App Service**.
2. Go to the **"Settings"** tab.
3. Scroll down to **"Networking"**.
4. Click **"Generate Domain"** (or add a custom domain).
5. Copy the generated URL (e.g., `food-heaven-production.up.railway.app`).

## 6. Access your Site!
- Open the URL in your browser.
- Your app is now live with a real PostgreSQL database!
