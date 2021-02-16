using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LSFProject.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LSFProject.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles =("Admin,Manager"))]
    public class AddedPostModel : PageModel
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
            [Required(ErrorMessage = "�� ������ ���������!")]
            public string Header { get; set; }
            [Required(ErrorMessage = "�� ������ ������ �����!")]
            public string PreviewText { get; set; }
            public string PreviewPhoto { get; set; }
            [Required(ErrorMessage = "�� ������ Url-����� �������!")]
            public string Url { get; set; }
            public string Description { get; set; }
            public DateTime Date { get; set; }
            [Required(ErrorMessage = "�� ������ �����!")]
            public string Author { get; set; }
            public int Blocked { get; set; }
            public int Watching { get; set; }
        }
        LSFProjectContext _context = new LSFProjectContext();
        IWebHostEnvironment _appEnvironment;
        public AddedPostModel(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }
        public async Task<IActionResult> OnPostAsync(string editor, IFormFile inputImage)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Random rand = new Random();
                    if (_context.AspNetNews.Where(news => news.Url == Input.Url).ToList().Count != 0)
                        Input.Url = Input.Url + rand.Next(9999);
                    string path;
                    if (inputImage != null)
                    {
                        path = "/img/latest-news/" + Input.Url + inputImage.FileName;
                    }
                    else
                    {
                        path = "/img/latest-news/Not-found-image.jpg";
                    }
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await inputImage.CopyToAsync(fileStream);
                    }
                    AspNetNews news = new AspNetNews()
                    {
                        Author = Input.Author,
                        PreviewPhoto = _context.AspNetFiles.FirstOrDefault(p => p.Title == path).Id,
                        Blocked = false,
                        Date = DateTime.Now,
                        Description = editor,
                        Header = Input.Header,
                        Likes = 0,
                        PreviewText = Input.PreviewText,
                        Share = 0,
                        Url = Input.Url,
                        Watching = 0
                    };
                    _context.AspNetNews.Add(news);
                    await _context.SaveChangesAsync();
                    StatusMessage = "������� ������� ��������� �� ����!";
                    return RedirectToPage("./Posts");
                }
                catch
                {
                    ErrorMessage = "��������� ������, ������� �� ���������!";
                    return RedirectToPage("./Posts");
                }
            }
            else
            {
                return Page();
            }
        }
    }
}
