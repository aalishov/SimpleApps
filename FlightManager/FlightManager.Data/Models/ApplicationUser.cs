using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManager.Data.Models
{
   public class ApplicationUser:IdentityUser
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.OnCreated = DateTime.UtcNow;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Egn { get; set; }
        public string Address { get; set; }
        public DateTime OnCreated { get; set; }
    }
}
