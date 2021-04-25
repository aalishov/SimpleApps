using HousekeeperManager.Services;
using HousekeeperManager.ViewModels.Missions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HousekeeperManager.Web.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IMissionsService missionService;

        public ClientsController(IMissionsService missionService)
        {
            this.missionService = missionService;
        }
        public IActionResult Index()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ICollection<MissionClientIndexVM> model = missionService.GetAllMissionsForClient(userId);
            return View(model);
        }
    }
}
