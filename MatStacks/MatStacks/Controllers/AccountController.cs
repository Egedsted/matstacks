using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatStacks.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        private readonly SignInManager<IdentityUser> signInManager;

        //Her er et super eksempel på en Dependency Injection :))
        //HVAD ER EN DEPENDENCY INJECTION???? vvvv
        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View(new MatStacks.Models.User());
        }

        public IActionResult Register()
        {
            return View(new MatStacks.Models.User());
        }

        [HttpPost]
        public async Task<IActionResult> Register(MatStacks.Models.User user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var identityUser = new IdentityUser { Email = user.EmailAddress, UserName = user.EmailAddress};

            var result = await userManager.CreateAsync(identityUser,user.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors.Select(x => x.Description))
                {
                    ModelState.AddModelError("", error);
                }
                return View();
            }

            return RedirectToAction("Login");
        }
    }
}
