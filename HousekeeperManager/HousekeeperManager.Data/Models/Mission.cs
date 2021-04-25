using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HousekeeperManager.Data.Models
{
    public class Mission
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        public DateTime TimeLimit { get; set; }

        public DateTime FinishDate { get; set; }

        public double Budget { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int StatusId { get; set; }

        public virtual Status Status { get; set; }

        public string ClientId { get; set; }

        public virtual Client Client { get; set; }

        public string HousekeeperId { get; set; }

        public virtual Housekeeper Housekeeper { get; set; }
    }
}
