using System;
using System.Threading.Tasks;

namespace HousekeeperManager.Data.Seeding
{
    interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider);
    }
}
