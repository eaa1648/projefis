using projefis.Data;
using projefis.Models;
using BCrypt.Net;
using System.Linq;
using System.Threading.Tasks;

public static class DataSeeder
{
    public static async Task SeedData(AppDbContext context)
    {
        if (!context.Users.Any(u => u.UserName == "admin"))
        {
            var adminUser = new User
            {
                UserName = "admin",
                Email = "admin@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("adminpassword"), // Admin şifresi hash'leniyor
                IsAdmin = true // Admin rolü ekleniyor
            };

            context.Users.Add(adminUser);
            await context.SaveChangesAsync();
        }
    }
}
