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
        public async Task<IActionResult> Index()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            ICollection<MissionClientIndexVM> model = await missionService.GetAllMissionsForClientAsync(userId);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MissionCreate()
        {
            MissionCreateVM model = new MissionCreateVM()
            {
                TimeLimit = DateTime.UtcNow.AddDays(1),
                CategoryItems = await missionService.GetCategoriesItemsAsync(),
                LocationItems = await missionService.GetLocationsItemsAsync(),
                Budget=25,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MissionCreate(MissionCreateVM model)
        {
            model.ClientId = await missionService.GetClientId(this.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            model.StatusId = await missionService.GetStatusId("Чакаща");

            if (!ModelState.IsValid)
            {
                model.CategoryItems = await missionService.GetCategoriesItemsAsync();
                model.LocationItems = await missionService.GetLocationsItemsAsync();
                model.Budget = 25;
                return this.View(model);
            }

            await missionService.CreateMissionAsync(model);
            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpGet]
        public async Task<IActionResult> MissionDetails(int id)
        {
            MissionDetailsVM model = await missionService.GetMissionDetailsAsync(id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MissionDelete(int id)
        {
            await missionService.DeleteMissionAsync(id);
            return RedirectToAction(nameof(this.Index));
        }
    }
}
