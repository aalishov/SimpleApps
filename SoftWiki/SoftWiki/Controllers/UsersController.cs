using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoftWiki.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftWiki.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("logout")]
        public string Logout()
        {
            return "Logout";
        }

        [HttpPost("login")]
        public User Login(User user)
        {
            return user;
        }
    }

    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
