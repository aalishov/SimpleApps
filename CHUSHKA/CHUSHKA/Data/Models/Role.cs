using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHUSHKA.Data.Models
{
    public class Role : IdentityRole
    {
        public Role()
    : this(null)
        {
        }

        public Role(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
