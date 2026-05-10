using FoodHeaven.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodHeaven.Data
{
    public static class SeedAdmins
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Ensure auth is created
                context.Database.EnsureCreated();

                var admins = new[]
                {
                    new Admin
                    {
                        Username = "admin",
                        Email = "admin@foodheaven.com",
                        PlainPassword = "admin@123",
                        FullName = "Admin User",
                        IsActive = true,
                        CreatedAt = DateTime.Now
                    },
                    new Admin
                    {
                        Username = "Asad",
                        Email = "asad.spartan300@gmail.com",
                        PlainPassword = "asad123",
                        FullName = "Asad Khan",
                        IsActive = true,
                        CreatedAt = DateTime.Now
                    }
                };

                foreach (var admin in admins)
                {
                    var existingAdmin = await context.Admins.FirstOrDefaultAsync(a => a.Username == admin.Username);
                    if (existingAdmin == null)
                    {
                        context.Admins.Add(admin);
                    }
                    else
                    {
                        // Update password to ensure it matches requirement
                        existingAdmin.PlainPassword = admin.PlainPassword;
                        existingAdmin.FullName = admin.FullName;
                    }
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
