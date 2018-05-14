using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Planner.ViewModels;
using System.Threading.Tasks;

namespace BaseballPlanner.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
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
        public async Task<IActionResult> Register(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = viewModel.Username };
                var result = await _userManager.CreateAsync(user, viewModel.Password);

                if (result.Succeeded)
                {
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

    }
}