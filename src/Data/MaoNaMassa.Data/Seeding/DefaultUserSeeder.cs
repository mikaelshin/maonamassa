namespace MaoNaMassa.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using MaoNaMassa.Common;
    using MaoNaMassa.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class DefaultUserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedDefaultUserAsync(dbContext, userManager);
        }

        private static async Task SeedDefaultUserAsync(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            //if (userManager.FindByEmailAsync("admin@admin.com").Result == null)
            //{
            //    var admin = new Administrator
            //    {
            //        FirstName = "Mikael",
            //        LastName = "Shin",
            //        UserName = "mikaelshin",
            //        Email = "admin@admin.com",
            //        //Location = Country.BG,
            //        ProfileImageUrl = "",
            //        PasswordHash = "mikaelshin",
            //    };

            //    await db.Users.AddAsync(admin);
            //    await db.SaveChangesAsync();
            //    await userManager.AddToRoleAsync(admin, "Administrator");
            //}
        }
    }
}
