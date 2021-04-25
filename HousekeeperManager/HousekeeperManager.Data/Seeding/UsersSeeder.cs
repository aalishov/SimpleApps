using HousekeeperManager.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousekeeperManager.Data.Seeding
{
    public class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Users.Any())
            {
                return;
            }

            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();


            await SeedUserAsync(dbContext, userManager, roleManager, "Admin", "Admin", "admin@abv.bg", "123456", "Administrator");
            await SeedUserAsync(dbContext, userManager, roleManager, "Housekeeper", "1", "housekeeper1@abv.bg", "123456", "Housekeeper");
            await SeedUserAsync(dbContext, userManager, roleManager, "Housekeeper", "2", "housekeeper2@abv.bg", "123456", "Housekeeper");
            await SeedUserAsync(dbContext, userManager, roleManager, "Housekeeper", "3", "housekeeper3@abv.bg", "123456", "Housekeeper");
            await SeedUserAsync(dbContext, userManager, roleManager, "Client", "1", "client1@abv.bg", "123456", "Client");
            await SeedUserAsync(dbContext, userManager, roleManager, "Client", "2", "client2@abv.bg", "123456", "Client");

            await AsignUserToClientsAndHousekeepr(dbContext, serviceProvider);
        }
        private static async Task SeedUserAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, string firstName, string lastName, string email, string password, string roleName)
        {
            ApplicationUser user = await userManager.FindByNameAsync(email);
            if (user == null)
            {
                IdentityResult result = await userManager.CreateAsync(
                    new ApplicationUser()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        UserName = email,
                        Email = email,
                    }, password);


                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }

            user = await userManager.FindByNameAsync(email);

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


        public async Task AsignUserToClientsAndHousekeepr(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();


            foreach (var user in dbContext.Users)
            {
                if (await userManager.IsInRoleAsync(user, "Client"))
                {
                    _ = dbContext.Clients.Add(new Client() { ApplicationUser = user });
                }
                else if (await userManager.IsInRoleAsync(user, "Housekeeper"))
                {
                    _ = dbContext.Housekeepers.Add(new Housekeeper() { ApplicationUser = user });
                }
            }
            _ = await dbContext.SaveChangesAsync();
        }

    }
}
