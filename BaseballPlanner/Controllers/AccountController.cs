using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Planner.Config;
using Planner.Models;
using Planner.Models.Helper;
using Planner.ViewModels;
using System;
using System.Net;
using System.Threading.Tasks;

namespace BaseballPlanner.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private readonly IOptions<AuthMessageSenderOptions> _config;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IOptions<AuthMessageSenderOptions> config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
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

            ModelState.AddModelError("", "Benutzername oder Kennwort ungültig.");
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
                var user = new User()
                {
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

        public ActionResult MailTest()
        {
            EMailSender sender = new EMailSender(_config);
            sender.SendEmail("jurtzmarcel@gmail.com", "Testmail 1", "Hello World!");
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View(new ForgotPasswordViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var user = await _userManager.FindByEmailAsync(viewModel.Email);
            if (user == null)
                return View("ForgotPasswordConfirmation");

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = Url.Action("ResetPassword", "Account", new { UserId = user.Id, code = code }, protocol: Request.Scheme);

            EMailSender sender = new EMailSender(_config);
            await sender.SendEmail(user.Email, "Kennwort zurückgesetzt", "Please reset your password by clicking here: <a href=\"" + callbackUrl + "\">link</a>");

            return View("ForgotPasswordConfirmation");
        }

        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            if (code == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            var viewModel = new ResetPasswordViewModel();
            viewModel.Code = code;

            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}