# PreSIZEly – E-Commerce Web App with Size Calculator

**PreSIZEly** is a local web application for a sustainable e-commerce platform. It offers size recommendation through a built-in calculator to reduce product returns. Built using **ASP.NET Core Blazor**, it supports user authentication, cart management, product browsing, and payment simulation with Stripe (test keys).

---

## Tools & Technologies Used

| Tool/Framework       | Purpose                                 |
|----------------------|------------------------------------------|
| ASP.NET Core Blazor  | Web app frontend/backend (server-side)   |
| Entity Framework Core| ORM for database management              |
| Microsoft SQL Server | Local development database               |
| Identity Framework   | User authentication/authorization        |
| Stripe API (Test Key)| Simulated payment gateway                |
| Radzen Blazor        | UI Components                            |
| Bootstrap CSS        | Responsive styling                       |
| Visual Studio        | Development IDE                          |

---

## Project Structure

```
PresizelyWeb/
│
├── Data/                    # Entity models & DbContext
├── Repository/             # Repositories for data access logic
├── Components/             # Razor components (UI logic)
├── Pages/                  # Razor pages (views)
├── Services/               # Application services (e.g. payment)
├── wwwroot/                # Static files (CSS, JS, images)
├── appsettings.json        # Configuration (including connection strings)
├── Program.cs              # Entry point & service configuration
```

---

## Setup Instructions (Local)

1. **Clone the Repository**
   ```bash
   git clone https://github.com/your-username/PresizelyWeb.git
   cd PresizelyWeb
   ```

2. **Set up the Database**
   Ensure you are using a local SQL Server or LocalDB. Example connection string in `appsettings.json`:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=PresizelyWeb;Trusted_Connection=True;"
   }
   ```

3. **Apply Migrations**
   Run the following command in terminal or Package Manager Console:
   ```bash
   dotnet ef database update
   ```

4. **Run the App**
   ```bash
   dotnet run
   ```
   Then open your browser at `https://localhost:5001`

---

## Features

- 👕 Browse categories and clothing items
- 📏 Size calculator embedded with each product
- 🛒 Shopping cart functionality
- 🔐 User login and registration
- 💳 Stripe test checkout simulation
- 🖼 Image-rich product gallery
- ⚙️ Admin role 

---

## Sample Screenshots

Screenshots available in wwwroot/lib/screenshots
---

## Test Stripe Key

For Stripe simulation, you can use:
- **Card Number**: `4242 4242 4242 4242`
- **Expiry**: Any future date
- **CVC**: Any 3 digits


---

## Notes

- The app runs locally.
- Migration and seeding are handled via `OnModelCreating` in `ApplicationDbContext`.
