using Learning1.DataAccess.Data;
using Learning1.DataAccess.Utility;
using Learning1.Models;
using Learning1.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LearningPractice.Areas.Account.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        SignInManager<ApplicationUser> _signInManager;
        UserManager<ApplicationUser> _userManager;
        RoleManager<IdentityRole> _roleManager;
        public AccountController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Employee/Home/Index");
                }
                ModelState.AddModelError("", "An invalid Attempt");

            }
            return View();
        }

        public async Task<IActionResult> Register()
        {
            if (!_roleManager.RoleExistsAsync(Helpers.Admin).GetAwaiter().GetResult())
            {
               await _roleManager.CreateAsync(new IdentityRole(Helpers.Admin));
               await _roleManager.CreateAsync(new IdentityRole(Helpers.Employee));

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name,
                };
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.RoleName);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    
                }
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
