using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CHUSHKA.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

    }
}
