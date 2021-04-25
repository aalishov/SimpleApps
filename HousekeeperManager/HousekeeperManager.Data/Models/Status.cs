
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HousekeeperManager.Data.Models
{
    public class Status
    {
        public Status()
        {
            this.Missions = new HashSet<Mission>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Mission> Missions { get; set; } 
    }
}
