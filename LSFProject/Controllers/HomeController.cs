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
            if (!_context.AspNetNews.Any(news => news.Url == url) || _context.AspNetNews.FirstOrDefault(news => news.Url == url).Blocked)
            {
                Response.StatusCode = 404;
                return View("NewsNotFound");
            }
            _context.AspNetNews.FirstOrDefault(newsItem => newsItem.Url == url).Watching++;
            _context.SaveChanges();
            return View(_context.AspNetNews.Where(newsIdItem => newsIdItem.Url == url).ToList()[0]);
        }
        [Authorize]
        public async Task<IActionResult> CreateComment(AspNetNewsComment comment, string message, string idNews, string idUser)
        {
            AspNetNewsComment _comment = new AspNetNewsComment()
            {
                Date = DateTime.Now,
                NewsId = int.Parse(idNews),
                Text = message,
                UserId =  idUser
            };
            _context.AspNetNewsComments.Add(_comment);
            await _context.SaveChangesAsync();
            return RedirectToAction("NewsDetails", "Home", new { url = _context.AspNetNews.Where(news => news.Id == int.Parse(idNews)).ToList()?[0].Url });
        }
    }
}
