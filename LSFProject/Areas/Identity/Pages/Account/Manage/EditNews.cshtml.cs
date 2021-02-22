using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LSFProject.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = ("Admin,Manager"))]
    public class EditNewsModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "Не указан Заголовок!")]
            public string Header { get; set; }
            [Required(ErrorMessage = "Не указан превью текст!")]
            public string PreviewText { get; set; }
            public int PreviewPhoto { get; set; }
            [Required(ErrorMessage = "Не указан Url-адрес новости!")]
            public string Url { get; set; }
            public string Description { get; set; }
            public DateTime Date { get; set; }
            [Required(ErrorMessage = "Не указан Автор!")]
            public string Author { get; set; }
            public bool Blocked { get; set; }
            public int Watching { get; set; }
        }

        readonly LSFProjectContext _context = new LSFProjectContext();
        readonly IWebHostEnvironment _appEnvironment;
        public EditNewsModel(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }
        public void OnGet(AspNetNews news)
        {
            Input = new InputModel()
            {
                Author = news.Author,
                Date = news.Date,
                Blocked = news.Blocked,
                Id = news.Id,
                Description = news.Description,
                Header = news.Header,
                PreviewPhoto = news.PreviewPhoto,
                PreviewText = news.PreviewText,
                Url = news.Url,
                Watching = news.Watching
            };
        }
        public async Task<IActionResult> OnPostSaveChangeNewsAsync(string editor, IFormFile inputImage)
        {
            Random rand = new Random();
            if (_context.AspNetNews.Where(newsDb => newsDb.Url == Input.Url).ToList().Count != 0)
                Input.Url = Input.Url + rand.Next(9999999);
            if (inputImage != null)
            {
                string path = "/images/posts-images/" + Input.Url + inputImage.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await inputImage.CopyToAsync(fileStream);
                }
                _context.AspNetNews.FirstOrDefault(post => post.Id == Input.Id).PreviewPhoto = _context.AspNetFiles.FirstOrDefault(p => p.Title == path).Id;
            }
            _context.AspNetNews.FirstOrDefault(post => post.Id == Input.Id).Author = Input.Author;
            _context.AspNetNews.FirstOrDefault(post => post.Id == Input.Id).Date = DateTime.Now;
            _context.AspNetNews.FirstOrDefault(post => post.Id == Input.Id).Description = editor;
            _context.AspNetNews.FirstOrDefault(post => post.Id == Input.Id).Header = Input.Header;
            _context.AspNetNews.FirstOrDefault(post => post.Id == Input.Id).PreviewText = Input.PreviewText;
            _context.AspNetNews.FirstOrDefault(post => post.Id == Input.Id).Url = Input.Url;
            _context.SaveChanges();
            return RedirectToPage("./Posts");
        }
    }
}
