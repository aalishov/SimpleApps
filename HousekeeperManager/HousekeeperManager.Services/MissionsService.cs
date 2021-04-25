using HousekeeperManager.Data;
using HousekeeperManager.ViewModels.Missions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HousekeeperManager.Services
{
    public class MissionsService : IMissionsService
    {
        private readonly ApplicationDbContext context;

        public MissionsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public ICollection<MissionClientIndexVM> GetAllMissionsForClient(string userId)
        {
            return this.context.Missions
                .Where(x => x.Client.ApplicationUserId == userId)
                .Select(x => new MissionClientIndexVM()
                {
                    Id = x.Id,
                    Budget = x.Budget.ToString(),
                    Location = x.Location.Name,
                    Address = x.Location.Address,
                    Category = x.Category.Name,
                    Status = x.Status.Name
                }).ToList();
        }
    }
}
