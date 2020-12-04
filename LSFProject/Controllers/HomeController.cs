using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LSFProject.Models;
using LSFProject.ViewModels;
using LSFProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace LSFProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        LSFProjectContext _context = new LSFProjectContext();

        public HomeController( ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() => View();


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult AboutOfServices() => View();


        public IActionResult NewsDetails(string url)
        {
            var news = _context.News.Where(news => news.Url == url).ToList();
            if (news.Count == 0 || news[0].Blocked)
            {
                Response.StatusCode = 404;
                return View("NewsNotFound");
            }
            _context.News.FirstOrDefault(newsItem => newsItem.Url == url).Watching++;
            _context.SaveChanges();
            return View(_context.News.Where(newsIdItem => newsIdItem.Url == url).ToList()[0]);
        }
        [Authorize]
        public async Task<IActionResult> CreateComment(Comment comment, string message, string idNews, string idUser)
        {
            Comment _comment = new Comment()
            {
                Date = DateTime.Now,
                NewsId = int.Parse(idNews),
                Answer = false,
                Text = message,
                UserId =  idUser
            };
            _context.Comments.Add(_comment);
            await _context.SaveChangesAsync();
            return RedirectToAction("NewsDetails", "Home", new { url = _context.News.Where(news => news.Id == int.Parse(idNews)).ToList()?[0].Url });
        }
    }
}
