using CHUSHKA.Data;
using CHUSHKA.Data.Models;
using CHUSHKA.Models;
using CHUSHKA.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CHUSHKA.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<Role> roleManager;
        private readonly ApplicationDbContext context;

        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.context = context;
        }

        [Route("/")]
        public IActionResult Index()
        {
            bool isAdmin = this.User.IsInRole("Admin");

            if (this.User.IsInRole("Admin"))
            {
                return RedirectToAction(nameof(AdminHome));
            }
            else if (this.User.IsInRole("User"))
            {
                return RedirectToAction(nameof(UserHome));
            }
            else
            {
                return RedirectToAction(nameof(GuestHome));
            }
        }

        public IActionResult AdminHome()
        {
            return View();
        }
        public IActionResult UserHome()
        {
            return View();
        }

        [Route("Index")]
        public IActionResult GuestHome()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            if (userName == null || password == null)
            {
                return View();
            }

            var result = await this.signInManager.PasswordSignInAsync(userName, password, false, false);

            if (result.Succeeded)
            {
                return this.RedirectToAction(nameof(Index));
            }

            return View();
        }
        [Route("/logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return this.RedirectToAction(nameof(Index));
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel inputModel)
        {
            if (this.ModelState.IsValid && inputModel.Password == inputModel.ConfirmPassword)
            {
                var user = new User() 
                { 
                    FirstName = inputModel.FirstName, 
                    LastName = inputModel.LastName, 
                    UserName = inputModel.UserName, 
                    Email = inputModel.Email,
                    EmailConfirmed=true
                };

                var result =await this.userManager.CreateAsync(user, inputModel.Password);

                if (result.Succeeded)
                {
                    var roleExists = await this.roleManager.RoleExistsAsync("User");

                    if (roleExists)
                    {
                        var resultRoleAdded = await this.userManager.AddToRoleAsync(user, "User");

                        if (!resultRoleAdded.Succeeded)
                        {
                            throw new Exception(string.Join(Environment.NewLine, resultRoleAdded.Errors.Select(e => e.Description)));
                        }
                    }

                    this.signInManager.SignInAsync(user, isPersistent: false).GetAwaiter().GetResult();


                    return this.RedirectToAction(nameof(Index));
                }


            }
            return View(inputModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
