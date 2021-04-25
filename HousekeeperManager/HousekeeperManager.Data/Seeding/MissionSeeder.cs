using HousekeeperManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousekeeperManager.Data.Seeding
{
    public class MissionSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }
            List<Category> categories = new List<Category>()
            {
                new Category() { Name = "Почистване и дезинфекция" },
                new Category() { Name = "Грижа за домашни любимци и растения" },
                new Category() { Name = "Грижа за дете" },
                new Category() { Name = "Грижа за възрастен човек" }
            };

            List<Status> statuses = new List<Status>()
            {
                new Status() { Name = "Чакаща" },
                new Status() { Name = "Назначена на домашен помощник" },
                new Status() { Name = "За преглед" },
                new Status() { Name = "Изпълнена" },
                new Status() { Name = "Отказана" }
            };

            string clientId = dbContext.Clients.FirstOrDefault().Id;
            List<Location> locations = new List<Location>()
            {
                new Location() { Name = "Офис",Address="Кристал 10", ClientId = clientId },
                new Location() { Name = "Вила", Address = "Вихрен 12" ,ClientId=clientId},
                new Location() { Name = "Къща", Address = "Пионерска 10", ClientId = clientId }
            };

            List<Mission> missions = new List<Mission>()
            {
                new Mission(){
                    Name="Почистване",
                    Description="Цялостно почистване",
                    Location=locations.FirstOrDefault(),
                    TimeLimit=DateTime.UtcNow.AddDays(12),
                    Budget=80,
                    Category=categories.FirstOrDefault(),
                    Status=statuses.FirstOrDefault(),
                    ClientId=clientId
                },
                    new Mission(){
                    Name="Почистване 2",
                    Description="Цялостно почистване 2",
                    Location=locations.FirstOrDefault(),
                    TimeLimit=DateTime.UtcNow.AddDays(5),
                    Budget=80,
                    Category=categories.FirstOrDefault(),
                    Status=statuses.FirstOrDefault(),
                    ClientId=clientId
                }
            };

            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.Statuses.AddRangeAsync(statuses);
            await dbContext.Locations.AddRangeAsync(locations);
            await dbContext.Missions.AddRangeAsync(missions);
            _ = await dbContext.SaveChangesAsync();
        }
    }
}
