using System.ComponentModel.DataAnnotations;

namespace HousekeeperManager.ViewModels.Missions
{
    public class MissionClientIndexVM
    {
        public int Id { get; set; }

        [Display(Name = "Бюджет")]
        public string Budget { get; set; }

        [Display(Name = "Категория")]
        public string Category { get; set; }

        [Display(Name = "Обект")]
        public string Location { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Статус")]
        public string Status { get; set; }
    }
}
