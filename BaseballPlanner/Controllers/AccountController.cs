using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Planner.Models;
using Planner.Models.Helper;
using Planner.ViewModels;
using System;
using System.Threading.Tasks;

namespace BaseballPlanner.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var user = await _userManager.FindByNameAsync(viewModel.Username);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, viewModel.Password, false, false);
                if (result.Succeeded)
                {
                    var s = User.Identity.IsAuthenticated;

                    if (string.IsNullOrEmpty(viewModel.ReturnUrl))
                        return RedirectToAction("Index", "Home");

                    return Redirect(viewModel.ReturnUrl);
                }
            }

            ModelState.AddModelError("", "Username / Password not found");
            return View(viewModel);
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User() {
                    UserName = viewModel.Username,
                    Registered = DateTime.Now,
                    Email = viewModel.Mail
                };
                
                var result = await _userManager.CreateAsync(user, viewModel.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, RoleNames.ROLE_MEMBER);
                    await _userManager.UpdateAsync(user);
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}