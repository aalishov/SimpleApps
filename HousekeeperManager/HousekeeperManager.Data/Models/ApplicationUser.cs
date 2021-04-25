using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousekeeperManager.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string HousekeeperId { get; set; }

        public virtual Housekeeper Housekeeper { get; set; }

        public string ClientId { get; set; }

        public virtual Client Client { get; set; }

    }

}
