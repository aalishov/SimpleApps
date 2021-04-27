using HousekeeperManager.ViewModels.Missions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HousekeeperManager.Services
{
    public interface IMissionsService
    {
        public Task CreateMissionAsync(MissionCreateVM model);

        Task<ICollection<MissionClientIndexVM>> GetAllMissionsForClientAsync(string userId);

        Task<MissionDetailsVM> GetMissionDetailsAsync(int missioId);

        public Task<string> GetClientId(string userId);
      
        public Task<int> GetStatusId(string statusName);

        public Task<SelectList> GetStatusItemsAsync();

        public Task<SelectList> GetCategoriesItemsAsync();

        public Task<SelectList> GetLocationsItemsAsync();

        public Task DeleteMissionAsync(int missionId);
    }
}