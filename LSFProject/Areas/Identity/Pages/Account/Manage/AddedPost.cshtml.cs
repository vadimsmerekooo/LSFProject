using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LSFProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LSFProject.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = ("Admin,Manager"))]
    public class AddedPostModel : PageModel
    {
        [BindProperty] public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData] public string StatusMessage { get; set; }
        [TempData] public string ErrorMessage { get; set; }


        private readonly UserManager<LSFUser> _userManager;

        public AddedPostModel(UserManager<LSFUser> userManager)
        {
            _userManager = userManager;
        }

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

        readonly LSFProjectContext _context = new LSFProjectContext();

        public async Task<IActionResult> OnPostCreateAsync(string editor, string photo)
        {
            if (ModelState.IsValid && _context.AspNetFiles.Any(p => p.Title == photo))
            {
                try
                {
                    if (_context.AspNetFiles.Any(p => p.Title == photo))
                    {
                        if (_context.AspNetNews.Any(u => u.Url == Input.Url))
                            Input.Url = Input.Url + new Random().Next(99999999);
                        
                        AspNetNews news = new AspNetNews()
                        {
                            Author = (_userManager.FindByNameAsync(Input.Author).Result).Id,
                            // ReSharper disable once PossibleNullReferenceException
                            PreviewPhoto = _context.AspNetFiles.FirstOrDefault(p => p.Title == photo).Id,
                            Status = StatusNews.Moderation,
                            Date = DateTime.Now,
                            Description = editor,
                            Header = Input.Header,
                            Likes = 0,
                            PreviewText = Input.PreviewText,
                            Share = 0,
                            Url = Input.Url,
                            Watching = 0,
                        };
                        await _context.AspNetNews.AddAsync(news);
                        await _context.SaveChangesAsync();

                        StatusMessage = "������� ������� ��������� � ���������� �� ���������.";

                        var link = Url.Action(nameof(LSFProject.Controllers.HomeController.NewsDetails), "Home",
                            new {url = Input.Url}, Request.Scheme,
                            Request.Host.ToString());
                        EmailSend.SendEmailAsync("vadim.a.shkuratov@gmail.com", "��������� ����� ������� �� ���������",
                            System.IO.File.ReadAllText("wwwroot/AddedPostEmailPage.html")
                                .Replace("UserEmail", _userManager.FindByNameAsync(User.Identity.Name).Result.Email)
                                .Replace("linkNewPostModeration", link));
                        return RedirectToPage("./Posts");
                    }
                    else
                    {
                        ErrorMessage =
                            "��������� ������, ������� �� ���������! ���� ��� ������ ������� ��� �� �������!";
                        return Page();
                    }
                }
                catch (Exception)
                {
                    ErrorMessage = "��������� ������, ������� �� ���������!";
                    return Page();
                }
            }
            else
            {
                return Page();
            }
        }
    }
}