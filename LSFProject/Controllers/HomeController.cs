using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LSFProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace LSFProject.Controllers
{
    public class HomeController : Controller
    {
        readonly LSFProjectContext _context = new LSFProjectContext();

        public IActionResult Index()
        {
            return View();
        }


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
        public async Task<IActionResult> CreateComment(string message, string idNews, string idUser)
        {
            AspNetNewsComment _comment = new AspNetNewsComment()
            {
                Date = DateTime.Now,
                NewsId = int.Parse(idNews),
                Text = message,
                UserId = idUser
            };
            _context.AspNetNewsComments.Add(_comment);
            await _context.SaveChangesAsync();
            return RedirectToAction("NewsDetails", "Home", new { url = _context.AspNetNews.Where(news => news.Id == int.Parse(idNews)).ToList()?[0].Url });
        }

        public Dictionary<string, string> listLinks = new Dictionary<string, string>();

        public IActionResult RazdelOBJ(string linkRazdel, string razdelName)
        {
            if (String.IsNullOrWhiteSpace(linkRazdel) || String.IsNullOrWhiteSpace(razdelName))
                return NotFound();

            Dictionary<string, string> objMenu = new Dictionary<string, string>()
            {
                {
                    "child/obj-for-child", "Островок безопасности"
                },
                {
                    "child/life-collective-safe", "Личная и коллективная безопасность" 
                },
                {
                    "child/safe-at-chs", "Защита от ЧС" 
                },
                {
                    "child/inside-and-safe", "Окружающая среда и безопасность" 
                },
                {
                    "child/health-life","Здоровый образ жизни"
                },
                {
                    "child/books", "Литература"
                },
                {
                    "child/videos", "Видео материалы"
                },
                {
                    "child/games", "Развивающие игры"
                },
                {
                    "child/test", "Тест"
                },
                //-----------------------------------------------------------
                {
                    "teenager/obj-for-teenager", "Не пропаду!?!"
                },
                {
                    "teenager/life-collective-safe", "Личная и коллективная безопасность"
                },
                {
                     "teenager/safe-at-chs", "Защита от ЧС"
                },
                {
                    "teenager/inside-and-safe", "Окружающая среда и безопасность"
                },
                {
                    "teenager/health-life", "Здоровый образ жизни"
                },
                {
                    "teenager/books", "Литература"
                },
                {
                    "teenager/videos", "Видео материалы"
                },
                {
                    "teenager/games", "Развивающие игры"
                },
                {
                    "teenager/test", "Тест"
                },
                //---------------------------------------------------------
                {
                    "adult/obj-for-adult", "Пригодится, чтобы выжить..."
                },
                {
                    "adult/obj-for-adult-life-collective-safe", "Личная и коллективная безопасность"
                },
                {
                    "adult/safe-at-chs", "Защита от ЧС"
                },
                {
                    "adult/health-life", "Здоровый образ жизни"
                },
                {
                    "adult/inside-and-safe", "Окружающая среда и безопасность"
                },
                {
                    "adult/books", "Литература"
                },
                {
                    "adult/videos", "Видео материалы"
                },
                {
                    "adult/games", "Игры"
                },
                {
                    "adult/test", "Тест"
                }
            };


            ViewData["List"] = objMenu.Where(x => x.Key.Contains(razdelName)).ToList();
            ViewData["Link"] = linkRazdel;
            ViewData["RazdelName"] = razdelName;
            ViewData["Responce"] = "obj-razdel/" + linkRazdel;

            return View();
        }
    }
}
