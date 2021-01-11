using System;
using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using CHUSHKA.Data.Models;
using Microsoft.Extensions.Configuration;

namespace CHUSHKA.Data.Seeder
{
    public class UserSeeder:ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Users.Any())
            {
                return;
            }

            var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            await SeedUserAsync(dbContext, userManager, roleManager, "Admin", "Admin", "admin@abv.bg", "admin@abv.bg", "123456", "Admin");
            await SeedUserAsync(dbContext, userManager, roleManager, "User", "User", "user@abv.bg", "user@abv.bg", "123456", "User");

        }
        private static async Task SeedUserAsync(ApplicationDbContext context, UserManager<User> userManager, RoleManager<Role> roleManager, string firstName, string lastName, string userName, string email, string password, string roleName)
        {
            User user = await userManager.FindByNameAsync(userName);
            if (user == null)
            {
                IdentityResult result = await userManager.CreateAsync(
                    new User()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        UserName = userName,
                        Email = email,
                    }, password);


                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }

            user = await userManager.FindByNameAsync(userName);

            var roleExists = await roleManager.RoleExistsAsync(roleName);

            if (roleExists)
            {
                var result = await userManager.AddToRoleAsync(user, roleName);

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
