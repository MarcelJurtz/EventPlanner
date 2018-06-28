using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Planner.Config;
using Planner.Helper;
using Planner.Models;
using Planner.Models.Helper;
using Planner.Models.Repository;
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
        private readonly INotificationConfigurationRepository _notificationConfigurationRepository;
        private readonly EMailSender _eMailSender;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IOptions<AuthMessageSenderOptions> config, INotificationConfigurationRepository configurationRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;
            _notificationConfigurationRepository = configurationRepository;
            _eMailSender = new EMailSender(config);
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
                        return RedirectToAction(MethodNames.INDEX, ControllerNames.HOME);

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
                    await _userManager.UpdateAsync(user);

                    var admins = await _userManager.GetUsersInRoleAsync(RoleNames.ROLE_ADMIN);
                    foreach (var admin in admins)
                    {
                        var config = _notificationConfigurationRepository.GetConfigurationForUser(admin.UserId);
                        if (config != null && config.NewUserRegistered)
                        {
                            await _eMailSender.SendUserConfirmationEmail(admin.Email);
                        }
                    }

                    return RedirectToAction(MethodNames.ACC_REGISTERED);
                }
                else
                {
                    ModelState.AddModelError("err_register", "Beim anlegen des Accounts ist ein Fehler aufgetreten. Die E-Mail Addresse oder der Benutzername ist bereits vergeben.");
                }
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(MethodNames.INDEX, ControllerNames.HOME);
        }

        public ActionResult AccessDenied()
        {
            return View();
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
                return View(MethodNames.ACC_FORGOT_PASSWORD_CONFIRMATION);

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = Url.Action(MethodNames.ACC_RESET_PASSWORD, ControllerNames.ACCOUNT, new { UserId = user.Id, code = code }, protocol: Request.Scheme);

            await _eMailSender.SendEmail(user.Email, "Kennwort zurückgesetzt", "Klicke hier, um dein Kennwort zurückzusetzen: <a href=\"" + callbackUrl + "\">link</a>");

            return View(MethodNames.ACC_FORGOT_PASSWORD_CONFIRMATION);
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
                return RedirectToAction(MethodNames.ACC_LOGIN);

            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
                return RedirectToAction(MethodNames.ACC_LOGIN);

            return View();
        }

        [AllowAnonymous]
        public IActionResult Registered()
        {
            return View();
        }
    }
}