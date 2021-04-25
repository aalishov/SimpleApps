using HousekeeperManager.ViewModels.Missions;
using System.Collections.Generic;

namespace HousekeeperManager.Services
{
    public interface IMissionsService
    {
        ICollection<MissionClientIndexVM> GetAllMissionsForClient(string userId);
    }
}