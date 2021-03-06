﻿using ClubGrid.Config;
using ClubGrid.Helper;
using ClubGrid.Models;
using ClubGrid.Repository;
using ClubGrid.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;

namespace ClubGrid.Controllers
{
    [Authorize(Roles = RoleNames.ROLE_MEMBER)]
    public class HomeController : Controller
    {
        private INewsRepository _newsRepository;
        private UserManager<User> _userManager;
        private AuthMessageSenderOptions _options;

        public HomeController(INewsRepository newsRepository, UserManager<User> userManager, IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
            _newsRepository = newsRepository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel();

            var newsList = _newsRepository.GetLastItems(_options.NewsCount).ToList();

            var results = from i in newsList
                          group i by i.GroupableDate into g
                          orderby g.Key descending
                          select g;

            viewModel.News = results;

            return View(viewModel);
        }
    }
}