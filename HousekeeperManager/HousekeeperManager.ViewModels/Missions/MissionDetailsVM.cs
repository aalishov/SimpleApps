using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HousekeeperManager.ViewModels.Missions
{
    public class MissionDetailsVM : MissionClientIndexVM
    {
        [Display(Name = "Описание")]
        public string Description { get; set; }



        [Display(Name = "Помощник")]
        public string HouseKeeper { get; set; }
    }
}
