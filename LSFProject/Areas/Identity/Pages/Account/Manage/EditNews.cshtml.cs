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
        readonly LSFProjectContext _context = new LSFProjectContext();
        readonly IWebHostEnvironment _appEnvironment;
        public AspNetFile files;


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
            [Required(ErrorMessage = "�� ������ ���������!")]
            public string Header { get; set; }
            [Required(ErrorMessage = "�� ������ ������ �����!")]
            public string PreviewText { get; set; }
            public int PreviewPhoto { get; set; }
            [Required(ErrorMessage = "�� ������ Url-����� �������!")]
            public string Url { get; set; }
            public string Description { get; set; }
            public DateTime Date { get; set; }
            [Required(ErrorMessage = "�� ������ �����!")]
            public string Author { get; set; }
            public StatusNews Status { get; set; }
            public int Watching { get; set; }
        }


        public EditNewsModel(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }
        public void OnGet(int id)
        {
            try
            {
                if (_context.AspNetNews.Any(n => n.Id == id))
                {
                    AspNetNews news = _context.AspNetNews.FirstOrDefault(n => n.Id == id);
                    Input = new InputModel()
                    {
                        Author = news.Author,
                        Date = news.Date,
                        Status = news.Status,
                        Id = news.Id,
                        Description = news.Description,
                        Header = news.Header,
                        PreviewPhoto = news.PreviewPhoto,
                        PreviewText = news.PreviewText,
                        Url = news.Url,
                        Watching = news.Watching
                    };
                    files = _context.AspNetFiles.FirstOrDefault(n => n.Id == Input.PreviewPhoto);
                }
            }
            catch
            {
            }
        }

        public async Task<IActionResult> OnPostSaveChangeNewsAsync(string photo)
        {
            if(ModelState.IsValid && _context.AspNetFiles.Any(p => p.Title == photo))
            {
                AspNetNews news = _context.AspNetNews.FirstOrDefault(n => n.Id == Input.Id);
                news.Header = Input.Header;
                news.PreviewPhoto = _context.AspNetFiles.FirstOrDefault(f => f.Title == photo).Id;
                news.PreviewText = Input.PreviewText;
                news.Author = Input.Author;
                news.Date = DateTime.Now;
                news.Description = Input.Description;
                _context.AspNetNews.Update(news);
                _context.SaveChanges();
                StatusMessage = "������� ������� ���������!";
                return RedirectToPage("./Posts");
            }
            StatusMessage = "������ ������� �� ������� ��������!";
            return RedirectToPage("./Posts");
        }
    }
}
