using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Planner.Models;
using Planner.Models.Helper;
using Planner.Models.Repository;
using Planner.ViewModels;
using System.Linq;

namespace BaseballPlanner.Controllers
{
    [Authorize(Roles = RoleNames.ROLE_MEMBER)]
    public class HomeController : Controller
    {
        private const int NEWS_COUNT = 10;
        private const string WELCOME_PREFIX = "Hallo, ";

        private INewsRepository _newsRepository;
        private UserManager<User> _userManager;

        public HomeController(INewsRepository newsRepository, UserManager<User> userManager)
        {
            _newsRepository = newsRepository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel();

            var newsList = _newsRepository.GetLastItems(NEWS_COUNT).ToList();

            var results = from i in newsList
                          group i by i.GroupableDate into g
                          orderby g.Key descending
                          select g;

            viewModel.WelcomeText = WELCOME_PREFIX + _userManager.GetUserName(User);
            viewModel.News = results;

            return View(viewModel);
        }
    }
}