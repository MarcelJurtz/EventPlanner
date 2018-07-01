using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Planner.Helper;
using Planner.Models;
using Planner.Models.Helper;
using Planner.Models.Repository;
using Planner.ViewModels;

namespace BaseballPlanner.Controllers
{
    [Authorize(Roles = RoleNames.ROLE_MEMBER)]
    public class UserSettingsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly INotificationConfigurationRepository _notificationConfigRepository;
        private readonly IStringLocalizer<UserSettingsController> _localizer;

        public UserSettingsController(UserManager<User> userManager, INotificationConfigurationRepository repo, IStringLocalizer<UserSettingsController> localizer)
        {
            _userManager = userManager;
            _notificationConfigRepository = repo;
        }

        public async Task<IActionResult> Index()
        {
            UserSettingsViewModel viewModel = new UserSettingsViewModel();

            if (User.IsInRole(RoleNames.ROLE_ADMIN))
            {
                var user = await _userManager.GetUserAsync(User);
                viewModel.NotificationConfiguration = _notificationConfigRepository.Find(x => x.AdminId == user.UserId).FirstOrDefault(); 
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(UserSettingsViewModel viewModel)
        {
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SavePassword(UserSettingsViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(MethodNames.INDEX, viewModel);

            var user = await _userManager.GetUserAsync(User);

            if (_userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, viewModel.OldPassword) == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError("", _localizer[UserSettingsStrings.SETT_ERR_INVALID_CREDENTIALS]);
                return RedirectToAction(MethodNames.INDEX, viewModel);
            }

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, viewModel.NewPassword);
            await _userManager.UpdateAsync(user);

            return RedirectToAction(MethodNames.INDEX, ControllerNames.HOME);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveNotificationConfiguration(UserSettingsViewModel viewModel)
        {
            if (!User.IsInRole(RoleNames.ROLE_ADMIN))
                return RedirectToAction(MethodNames.INDEX, viewModel);

            var user = await _userManager.GetUserAsync(User);
            NotificationConfiguration config = _notificationConfigRepository.Find(c => c.AdminId == user.UserId).FirstOrDefault();

            if (config == null)
            {
                config = new NotificationConfiguration();
                config.AdminId = user.UserId;
                _notificationConfigRepository.Add(config, false);
            }
            
            config.NewUserRegistered = viewModel.NotificationConfiguration.NewUserRegistered;
            config.UserParticipationUpdated = viewModel.NotificationConfiguration.UserParticipationUpdated;

            _notificationConfigRepository.CommitChanges();

            return RedirectToAction(MethodNames.INDEX, ControllerNames.HOME);
        }
    }
}