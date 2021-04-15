using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManager.Data.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {
            this.Id = Guid.NewGuid().ToString();
            this.OnCreated = DateTime.UtcNow;
        }
        public DateTime OnCreated { get; set; }
    }
}
