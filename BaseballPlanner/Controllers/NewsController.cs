using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Planner.Models;
using Planner.Models.Helper;
using Planner.Models.Repository;
using System;
using System.Linq;
using System.Net;

namespace BaseballPlanner.Controllers
{
    [Authorize(Roles = RoleNames.ROLE_ADMIN)]
    public class NewsController : Controller
    {
        private INewsRepository _newsRepository;

        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public IActionResult Index()
        {
            var news = _newsRepository.GetAll().OrderByDescending(n => n.Created);
            return View(news);
        }

        public ViewResult Add()
        {
            News news = new News();
            return View(news);
        }

        [HttpPost]
        public IActionResult Add(News news)
        {
            if (!ModelState.IsValid)
                return View(news);

            news.Created = DateTime.Now;
            _newsRepository.Add(news);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            News news = _newsRepository.Find(x => x.Id == id).FirstOrDefault();
            if (news == null)
                return StatusCode((int)HttpStatusCode.NotFound);
            else
                return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, News news)
        {
            if (!ModelState.IsValid)
                return View(news);

            if (id == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            var found = _newsRepository.Find(x => x.Id == id).FirstOrDefault();

            if (found == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            found.Content = news.Content;
            _newsRepository.CommitChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return StatusCode((int)HttpStatusCode.BadRequest);

            News news = _newsRepository.Find(x => x.Id == id).FirstOrDefault();
            if (news == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            return View(news);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            News news = _newsRepository.Find(x => x.Id == id).FirstOrDefault();
            if (news == null)
                return StatusCode((int)HttpStatusCode.NotFound);

            _newsRepository.Remove(news);

            return RedirectToAction("Index");
        }
    }
}