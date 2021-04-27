using HousekeeperManager.Data;
using HousekeeperManager.ViewModels.Missions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using HousekeeperManager.Data.Models;

namespace HousekeeperManager.Services
{
    public class MissionsService : IMissionsService
    {
        private readonly ApplicationDbContext context;

        public MissionsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<MissionClientIndexVM>> GetAllMissionsForClientAsync(string userId)
        {
            return await this.context.Missions
                .Where(x => x.Client.ApplicationUserId == userId)
                .Select(x => new MissionClientIndexVM()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Budget = x.Budget,
                    Location = x.Location.Name,
                    Address = x.Location.Address,
                    TimeLimit = x.TimeLimit.ToString("dddd, dd MMMM yyyy"),
                    Category = x.Category.Name,
                    Status = x.Status.Name
                }).ToListAsync();
        }

        public async Task<MissionDetailsVM> GetMissionDetailsAsync(int missioId)
        {
            return await this.context.Missions
                .Where(x => x.Id == missioId)
                .Select(x => new MissionDetailsVM()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Budget = x.Budget,
                    Location = x.Location.Name,
                    Address = x.Location.Address,
                    Category = x.Category.Name,
                    Status = x.Status.Name,
                    TimeLimit = x.TimeLimit.ToString("dddd, dd MMMM yyyy"),
                    HouseKeeper = x.Housekeeper != null ? string.Concat(x.Housekeeper.ApplicationUser.FirstName + " ", x.Housekeeper.ApplicationUser.LastName) : "-"
                })
                .FirstOrDefaultAsync();
        }

        public async Task<SelectList> GetCategoriesItemsAsync()
        {
            List<Category> items = await this.context.Categories.ToListAsync();
            return new SelectList(items, "Id", "Name");
        }

        public async Task<SelectList> GetLocationsItemsAsync()
        {
            List<Location> items = await this.context.Locations.ToListAsync();
            return new SelectList(items, "Id", "Name");

        }

        public async Task<SelectList> GetStatusItemsAsync()
        {
            List<Status> items = await this.context.Statuses.ToListAsync();
            return new SelectList(items, "Id", "Name");
        }

        public async Task CreateMissionAsync(MissionCreateVM model)
        {

            Mission mission = new Mission()
            {
                Name = model.Name,
                Description = model.Description,
                LocationId = model.LocationId,
                Budget = model.Budget,
                ClientId = model.ClientId,
                TimeLimit = model.TimeLimit,
                CategoryId = model.CategoryId,
                StatusId = model.StatusId,
            };
            await context.Missions.AddAsync(mission);
            await context.SaveChangesAsync();
        }

        public async Task<int> GetStatusId(string statusName)
        {
            var result = await this.context.Statuses.FirstOrDefaultAsync(x => x.Name == statusName);
            return result.Id;
        }

        public async Task<string> GetClientId(string userId)
        {
            var result = await this.context.Clients.FirstOrDefaultAsync(x => x.ApplicationUserId == userId);
            return result.Id;
        }

        public async Task DeleteMissionAsync(int missionId)
        {
            Mission mission = await this.context.Missions.FirstOrDefaultAsync(x => x.Id == missionId);
            this.context.Missions.Remove(mission);
            await this.context.SaveChangesAsync();
        }
    }
}
