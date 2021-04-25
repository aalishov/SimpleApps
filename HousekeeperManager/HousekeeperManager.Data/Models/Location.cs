using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HousekeeperManager.Data.Models
{
    public class Location
    {
        public Location()
        {
            this.Missions = new HashSet<Mission>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public string ClientId { get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<Mission> Missions { get; set; }
    }
}
