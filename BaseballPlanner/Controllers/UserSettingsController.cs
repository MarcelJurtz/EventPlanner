using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Planner.Models;
using Planner.ViewModels;

namespace BaseballPlanner.Controllers
{
    [Authorize]
    public class UserSettingsController : Controller
    {
        private readonly UserManager<User> _userManager;

        public UserSettingsController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(new UserSettingsViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(UserSettingsViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var user = await _userManager.GetUserAsync(User);

            if(_userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, viewModel.OldPassword) == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError("", "Dein eingegebenes altes Kennwort ist nicht korrekt.");
                return View(viewModel);
            }

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, viewModel.NewPassword);
            await _userManager.UpdateAsync(user);

            return View(viewModel);
        }
    }
}