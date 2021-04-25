using System;
using System.Collections.Generic;
using System.Text;

namespace HousekeeperManager.Data.Models
{
    public class Client
    {
        public Client()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Locations = new HashSet<Location>();
            this.Missions = new HashSet<Mission>();
        }
        public string Id { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Location> Locations { get; set; }

        public virtual ICollection<Mission> Missions { get; set; }
    }
}
