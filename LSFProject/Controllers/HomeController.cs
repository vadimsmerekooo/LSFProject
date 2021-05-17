using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using LSFProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using LSFProject.Models;
using LSFProject.ViewModelss;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MimeKit;
using MimeKit.Text;
using Org.BouncyCastle.Ocsp;

namespace LSFProject.Controllers
{
    public class HomeController : Controller
    {
        readonly LSFProjectContext _context = new LSFProjectContext();
        private UserManager<LSFUser> _userManager;

        public HomeController(UserManager<LSFUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public ActionResult AboutOfServices() => View();

        public IActionResult News(int page = 1)
        {
            int pageSize = 6;
            List<AspNetNews> source = _context.AspNetNews.OrderByDescending(date => date.Date)
                .Where(post => post.Status == StatusNews.Publish).ToList();
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Posts = items
            };
            return View(viewModel);
        }

        public IActionResult NewsDetails(string url)
        {
            if (_context.AspNetNews.Any(news => news.Url == url)
                && (User.IsInRole("Admin") || User.IsInRole("Manager"))
                && _context.AspNetNews.FirstOrDefault(news => news.Url == url).Status != StatusNews.Publish)
            {
                return View(_context.AspNetNews.Where(newsIdItem => newsIdItem.Url == url).ToList()[0]);
            }

            if (!_context.AspNetNews.Any(news => news.Url == url) ||
                _context.AspNetNews.FirstOrDefault(news => news.Url == url).Status == StatusNews.Blocked)
            {
                Response.StatusCode = 404;
                return View("NewsNotFound");
            }

            _context.AspNetNews.FirstOrDefault(newsItem => newsItem.Url == url).Watching++;
            _context.SaveChanges();
            return View(_context.AspNetNews.Where(newsIdItem => newsIdItem.Url == url).ToList()[0]);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult PublishNews(string url)
        {
            if (_context.AspNetNews.Any(newsItem => newsItem.Url == url))
            {
                _context.AspNetNews.FirstOrDefault(@post => post.Url == url).Status = StatusNews.Publish;
                _context.SaveChangesAsync();
            }

            return RedirectToAction("NewsDetails", new {url = url});
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteNews(int newsId)
        {
            _context.AspNetNews.Remove(_context.AspNetNews.FirstOrDefault(post => post.Id == newsId));
            foreach (var comments in _context.AspNetNewsComments.Where(comment => comment.NewsId == newsId))
            {
                _context.AspNetNewsComments.Remove(comments);
            }

            _context.SaveChanges();
            return RedirectToAction("News");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult BlockedNews(string url)
        {
            if (_context.AspNetNews.Any(n => n.Url == url))
            {
                _context.AspNetNews.FirstOrDefault(@post => post.Url == url).Status = StatusNews.Blocked;
                _context.SaveChangesAsync();
                return RedirectToAction("NewsDetails", new {url = url});
            }

            return RedirectToAction("News");
        }

        [Authorize]
        public async Task<IActionResult> CreateComment(string subject, string urlNews, string idUser)
        {
            AspNetNews news = _context.AspNetNews.FirstOrDefault(n => n.Url == urlNews);

            if (String.IsNullOrWhiteSpace(subject) || news is null)
            {
                return RedirectToAction("NewsDetails", "Home", new {url = news.Url});
            }

            List<string> forbidden_words =
                System.IO.File.ReadAllText("wwwroot/forbidden_words.txt").Split(',').ToList();

            foreach (string s in forbidden_words)
            {
                if (subject.Contains(s.Trim()))
                {
                    _context.AspNetUsers.FirstOrDefault(u => u.Id == idUser).LockoutEnd = DateTime.Now.AddMinutes(30);
                    _context.SaveChanges();
                    _userManager.ResetAuthenticatorKeyAsync(_userManager.FindByIdAsync(idUser).Result);
                    return RedirectToAction("NewsDetails", "Home", new {url = news.Url});
                }
            }

            AspNetNewsComment _comment = new AspNetNewsComment()
            {
                Date = DateTime.Now,
                NewsId = news.Id,
                Text = subject,
                UserId = idUser
            };
            _context.AspNetNewsComments.Add(_comment);
            _context.SaveChanges();
            return RedirectToAction("NewsDetails", "Home", new {url = news.Url});
        }

        [Authorize]
        public IActionResult DeleteComment(int idCom, string idUser, string urlNews)
        {
            if (_context.AspNetNewsComments.Any(c => c.Id == idCom))
            {
                AspNetNewsComment com = _context.AspNetNewsComments.FirstOrDefault(c => c.Id == idCom);
                _context.AspNetNewsComments.Remove(com);
                _context.SaveChanges();
            }

            return RedirectToAction("NewsDetails", "Home", new {url = urlNews});
        }

        private readonly Dictionary<string, string> objMenu = new Dictionary<string, string>()
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
                    "child/health-life", "Здоровый образ жизни"
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
        
        public IActionResult RazdelOBJ(string linkRazdel, string razdelName,int model = -1)
        {
            if (String.IsNullOrWhiteSpace(linkRazdel) || String.IsNullOrWhiteSpace(razdelName))
                return NotFound();

            ViewData["List"] = objMenu.Where(x => x.Key.Contains(razdelName)).ToList();
            ViewData["Link"] = linkRazdel;
            ViewData["RazdelName"] = razdelName;
            ViewData["Responce"] = "obj-razdel/" + linkRazdel;
            ViewData["Model"] = model;

            return View();
        }

        [Authorize]
        public IActionResult EmailSubscribe(string email, string returnUrl = "/")
        {
            if (String.IsNullOrWhiteSpace(email))
                return Redirect(returnUrl);

            if (_context.AspNetEmailSubscribe.Any(e => e.Email == email))
                return RedirectToPage("Index");

            if (_context.AspNetEmailSubscribe.Any(u => u.UserId == _userManager.GetUserId(User)))
            {
                _context.AspNetEmailSubscribe.FirstOrDefault(u => u.UserId == _userManager.GetUserId(User)).Email =
                    email;
                _context.AspNetEmailSubscribe.FirstOrDefault(u => u.UserId == _userManager.GetUserId(User))
                        .IsConfirmed =
                    false;

                var rolesUser = _userManager.GetRolesAsync(_userManager.GetUserAsync(User).Result);
                if (rolesUser.Result.Contains("Admin") || rolesUser.Result.Contains("Manager") ||
                    rolesUser.Result.Contains("MobileAdmin"))
                    _context.AspNetEmailSubscribe.FirstOrDefault(u => u.UserId == _userManager.GetUserId(User))
                            .InRoleAdmin =
                        true;

                _context.SaveChanges();
                EmailSendVerificateCode(_userManager.GetUserId(User), email,
                    "Подтверждение электронной почты на сайте " + Config.DomainName);
                return Redirect(returnUrl);
            }

            _context.AspNetEmailSubscribe.Add(new AspNetEmailSubscribe()
            {
                Email = email,
                UserId = _userManager.GetUserId(User),
                IsConfirmed = false,
                InRoleAdmin = false
            });
            _context.SaveChanges();
            EmailSendVerificateCode(_userManager.GetUserId(User), email,
                "Подтверждение электронной почты на сайте " + Config.DomainName);

            return RedirectToPage(returnUrl);
        }

        public IActionResult VerifyEmail(string userId, string code)
        {
            var user = _userManager.FindByIdAsync(userId);
            if (user == null)
                return BadRequest();

            if (_context.AspNetEmailSubscribe.Any(u => u.UserId == userId) &&
                _context.AspNetEmailSubscribe.FirstOrDefault(u => u.UserId == userId).Code == code)
            {
                _context.AspNetEmailSubscribe.FirstOrDefault(u => u.UserId == userId).IsConfirmed = true;
                _context.AspNetEmailSubscribe.FirstOrDefault(u => u.UserId == userId).Code = string.Empty;
                _context.SaveChanges();
                return View();
            }

            return BadRequest();
        }

        public IActionResult UnverifyEmail(string userId)
        {
            var user = _userManager.FindByIdAsync(userId);
            if (user == null)
                return BadRequest();

            var rolesUser = _userManager.GetRolesAsync(_userManager.FindByIdAsync(userId).Result);

            if (rolesUser.Result.Contains("Admin") || rolesUser.Result.Contains("Manager") ||
                rolesUser.Result.Contains("MobileAdmin"))
                return NotFound();

            if (_context.AspNetEmailSubscribe.Any(u => u.UserId == userId))
            {
                _context.AspNetEmailSubscribe.Remove(
                    _context.AspNetEmailSubscribe.FirstOrDefault(u => u.UserId == userId));
                _context.SaveChanges();
                return View();
            }

            return BadRequest();
        }

        [Authorize]
        public IActionResult RequestForRole(RequestForRoleModel model)
        {
            if (model == null)
                return RedirectToAction("Index");

            if (User.IsInRole("Admin") || User.IsInRole("Manager"))
                return RedirectToAction("Index");

            if (!_context.AspNetEmailSubscribe.Any(u => u.UserId == _userManager.GetUserId(User) && u.IsConfirmed))
                return RedirectToAction("Index");

            var link = Url.Action(nameof(Index), "Home",
                new {Areas = "Identity", Page = "/Account/Manage/UserInfo", userId = _userManager.GetUserId(User)},
                Request.Scheme,
                Request.Host.ToString());

            string messageText =
                $"Возраст: {model.Age}, Страна: {model.Country}, ФИО: {model.Name} {model.LastName}, Цель: {model.Text}";

            string message = System.IO.File.ReadAllText("wwwroot/RequestForRoleEmailPage.html")
                .Replace("UserEmail", _userManager.GetUserAsync(User).Result.Email).Replace("linkAccountUser", link);
            message = message.Replace("MessageText", messageText);

            EmailSend.SendEmailAsync("vadim.a.shkuratov@gmail.com", "Запрос на ролевое управление доступом", message);

            string userEmail = _context.AspNetEmailSubscribe
                .FirstOrDefault(u => u.UserId == _userManager.GetUserId(User)).Email;
            string userMessage = System.IO.File.ReadAllText("wwwroot/SendMessageUserEmailPage.html").Replace(
                "MessageText",
                $"Уважаемый {_userManager.GetUserAsync(User).Result.Email}, Ваша заявка успешно отправлена. В скором времени с Вами свяжеться администрация сайта.");

            EmailSend.SendEmailAsync(userEmail, "Заявка успешно отправлена", userMessage);


            return RedirectToAction("Index");
        }

        private async void EmailSendVerificateCode(string userId, string mailTo, string subject)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(_userManager.FindByIdAsync(userId)
                .Result);

            var link = Url.Action(nameof(VerifyEmail), "Home", new {userId = userId, code}, Request.Scheme,
                Request.Host.ToString());

            var unlink = Url.Action(nameof(UnverifyEmail), "Home", new {userId = userId}, Request.Scheme,
                Request.Host.ToString());

            _context.AspNetEmailSubscribe.FirstOrDefault(u => u.UserId == userId).Code = code;
            _context.SaveChanges();

            await EmailSend.SendEmailAsync(mailTo, subject,
                System.IO.File.ReadAllText("wwwroot/confimedEmailPage.html").Replace("linkForConfirmedEmail", link)
                    .Replace("linkForUnConfirmedEmail", unlink));
        }
        

        [HttpPost]
        [Authorize]
        public IActionResult ChekTest(int testId)
        {
            int countTest = 0;
            for (int i = 1; i <= 10; i++)
            {
                if (Request.Form.ContainsKey($"radio{i}") && Request.Form[$"radio{i}"] == "value")
                    countTest += 1;
            }


            if(_context.AspNetTestResults.Any(testc => testc.UserId == _userManager.GetUserId(User) && testc.TestId == testId))
            {
                var test = _context.AspNetTestResults.FirstOrDefault(testc => testc.UserId == _userManager.GetUserId(User) && testc.TestId == testId);
                if (test.IsBlocked)
                    return RedirectToAction("RazdelOBJ", routeValues:new {linkRazdel = "child/test", razdelName = "child"});
                
                test.LastResultTest = countTest;
                if (countTest > test.BestResultTest)
                {
                    test.BestResultTest = countTest;
                    if (_context.AspNetTestResults.Max(x => x.BestResultTest) < countTest)
                    {
                        foreach (var testResult in _context.AspNetTestResults.Where(t => t.TestId == testId))
                        {
                            testResult.IsBlocked = false;
                            _context.AspNetTestResults.Update(testResult);
                        }
                        test.IsBlocked = true;
                    }
                }

                if (test.CountPasses >= 3)
                {
                    test.IsBlocked = true;
                    test.CountPasses++;
                }
                else
                {
                    test.CountPasses++;
                }
                test.LastPlaythrough = DateTime.Now;
                _context.AspNetTestResults.Update(test);
            }
            else
            {
                AspNetTestResult test = new AspNetTestResult()
                {
                    LastPlaythrough = DateTime.Now,
                    TestId = testId,
                    UserId = _userManager.GetUserId(User),
                    BestResultTest = countTest,
                    LastResultTest = countTest
                };
                if (_context.AspNetTestResults.Max(x => x.BestResultTest) < countTest)
                {
                    test.IsBlocked = true;
                    foreach (var testResult in _context.AspNetTestResults)
                    {
                        testResult.IsBlocked = false;
                        _context.AspNetTestResults.Update(testResult);
                    }
                }
                _context.AspNetTestResults.Add(test);
            }

            _context.AspNetUsers.FirstOrDefault(u => u.Id == _userManager.GetUserId(User)).LevelXp += countTest;
            _context.SaveChanges();


            return RedirectToAction("RazdelOBJ", routeValues:new {linkRazdel = "child/test", razdelName = "child", model = countTest});
        }

        [HttpPost]
        public IActionResult SearchActionResult(string searchinput)
        {
            var users = _context.AspNetUsers.Where(user =>
                user.Email.Contains(searchinput.Trim())
                || user.Id.Contains(searchinput.Trim())
                || user.UserName.Contains(searchinput.Trim())
                || user.Email.Contains(searchinput.Trim())).ToList();
            var news = _context.AspNetNews.Where(newsx =>
                newsx.Author.Contains(searchinput.Trim())
                || newsx.Description.Contains(searchinput.Trim())
                || newsx.Header.Contains(searchinput.Trim())
                || newsx.Id.Equals(searchinput.Trim())
                || newsx.Url.Contains(searchinput.Trim())
                || newsx.PreviewText.Contains(searchinput.Trim())).ToList();
            var categoryes = _context.AspNetNewsCategories.Where(cat =>
                cat.Category.Contains(searchinput.Trim())).ToList();

            
            SearchViewModel searchViewModel = new SearchViewModel()
            {
                SearchQuery = searchinput,
                Categoryes = categoryes,
                News = news,
                Users = users
            };
            
            
            return View(searchViewModel);
        }
    }
}