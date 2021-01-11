using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHUSHKA.Data.Seeder
{
    public class TypeSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Types.Any())
            {
                dbContext.Types.Add(new Models.Type() { Name = "Food" });
                dbContext.Types.Add(new Models.Type() { Name = "Domestic" });
                dbContext.Types.Add(new Models.Type() { Name = "Health" });
                dbContext.Types.Add(new Models.Type() { Name = "Cosmetic" });
                dbContext.Types.Add(new Models.Type() { Name = "Other" });
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
