using Microsoft.AspNetCore.Mvc;
using Planner.Models.Repository;
using Planner.ViewModels;
using System.Linq;
using System.Net;

namespace BaseballPlanner.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ITeamRepository _teamRepository;

        public UserController(IUserRepository userRepository, ITeamRepository teamRepository)
        {
            _userRepository = userRepository;
            _teamRepository = teamRepository;
        }

        public IActionResult Index()
        {
            UserIndexViewModel viewModel = new UserIndexViewModel();
            viewModel.Users = _userRepository.GetAll();
            return View(viewModel);
        }

        public IActionResult Edit(int? id)
        {
            UserEditViewModel viewModel = new UserEditViewModel();

            if (id == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            viewModel.CurrentUser = _userRepository.Find(x => x.UserId == id).FirstOrDefault();
            viewModel.Teams = _teamRepository.GetAll();

            if (viewModel.CurrentUser == null)
                return StatusCode((int)HttpStatusCode.NotFound);
            else
                return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, UserEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            if (id == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            var found = _userRepository.Find(x => x.UserId == id).FirstOrDefault();

            if (found == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            // Save Teams
            // Save Role

            _userRepository.CommitChanges();

            return RedirectToAction("Index", "User");
        }
    }
}