using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Planner.Models;
using Planner.Models.Helper;
using Planner.Models.Repository;
using System;

namespace BaseballPlanner.Controllers
{
    public class NewsController : Controller
    {
        private INewsRepository _newsRepository;

        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = RoleNames.ROLE_ADMIN)]
        public ViewResult Add()
        {
            News news = new News();
            return View(news);
        }

        [HttpPost]
        [Authorize(Roles = RoleNames.ROLE_ADMIN)]
        public IActionResult Add(News news)
        {
            if (!ModelState.IsValid)
                return View(news);

            news.Created = DateTime.Now;
            _newsRepository.Add(news);

            return RedirectToAction("Index");
        }
    }
}