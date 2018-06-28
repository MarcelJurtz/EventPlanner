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
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BaseballPlanner.Controllers
{
    [Authorize(Roles = RoleNames.ROLE_ADMIN)]
    public class UserController : Controller
    {
        private UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly ITeamAssociationRepository _teamAssociationRepository;
        private readonly EMailSender _eMailSender;

        public UserController(UserManager<User> userManager, IUserRepository userRepository, ITeamRepository teamRepository, ITeamAssociationRepository teamAssociationRepository, IOptions<AuthMessageSenderOptions> config)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _teamRepository = teamRepository;
            _teamAssociationRepository = teamAssociationRepository;
            _eMailSender = new EMailSender(config);
        }

        public IActionResult Index()
        {
            UserIndexViewModel viewModel = new UserIndexViewModel();
            viewModel.Users = _userRepository.Find(x => x.Verified);
            return View(viewModel);
        }

        public IActionResult Unverified()
        {
            UserIndexViewModel viewModel = new UserIndexViewModel();
            viewModel.Users = _userRepository.Find(x => !x.Verified);
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            UserEditViewModel viewModel = new UserEditViewModel();

            if (id == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            viewModel.CurrentUser = _userRepository.Find(x => x.UserId == id).FirstOrDefault();
            viewModel.AllTeams = _teamRepository.GetAll().ToList();

            var associations = _teamAssociationRepository.Find(x => x.UserId == id);
            foreach(var team in viewModel.AllTeams)
            {
                team.Selected = associations.FirstOrDefault(x => x.TeamId == team.Id) != null;
            }
            viewModel.IsAdmin = await _userManager.IsInRoleAsync(viewModel.CurrentUser, RoleNames.ROLE_ADMIN);

            if (viewModel.CurrentUser == null)
                return StatusCode((int)HttpStatusCode.NotFound);
            else
                return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, UserEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            if (id == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            var found = _userRepository.Find(x => x.UserId == id).FirstOrDefault();

            if (found == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            // Save Teams
            _teamAssociationRepository.Update((int)id, viewModel.AllTeams);

            // Save / Remove Role
            bool userHasRole = await _userManager.IsInRoleAsync(found, RoleNames.ROLE_ADMIN);
            if (viewModel.IsAdmin && !userHasRole)
                await _userManager.AddToRoleAsync(found, RoleNames.ROLE_ADMIN);
            else if (!viewModel.IsAdmin && userHasRole)
                await _userManager.RemoveFromRoleAsync(found, RoleNames.ROLE_ADMIN);

            await _userManager.UpdateAsync(found);

            return RedirectToAction(MethodNames.INDEX);
        }

        public async Task<IActionResult> Confirm(int? id)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(MethodNames.USR_UNVERIFIED);

            if (id == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            var found = _userRepository.Find(x => x.UserId == id).FirstOrDefault();

            if (found == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            
            await _userManager.AddToRoleAsync(found, RoleNames.ROLE_MEMBER);
            await _userManager.UpdateAsync(found);

            found.Verified = true;

            _userRepository.CommitChanges();

            await _eMailSender.SendUserConfirmationEmail(found.Email);

            return RedirectToAction(MethodNames.USR_UNVERIFIED);
        }
    }
}