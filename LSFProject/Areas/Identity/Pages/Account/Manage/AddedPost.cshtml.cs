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
using Microsoft.EntityFrameworkCore.ChangeTracking;

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


        private UserManager<LSFUser> _userManager;

        public AddedPostModel(UserManager<LSFUser> userManager)
        {
            _userManager = userManager;
        }

        public class InputModel
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "Не указан Заголовок!")]
            public string Header { get; set; }
            [Required(ErrorMessage = "Не указан превью текст!")]
            public string PreviewText { get; set; }
            public string PreviewPhoto { get; set; }
            [Required(ErrorMessage = "Не указан Url-адрес новости!")]
            public string Url { get; set; }
            public string Description { get; set; }
            public DateTime Date { get; set; }
            [Required(ErrorMessage = "Не указан Автор!")]
            public string Author { get; set; }
            public int Blocked { get; set; }
            public int Watching { get; set; }
        }

        readonly LSFProjectContext _context = new LSFProjectContext();

        public async Task<IActionResult> OnPostCreateAsync(string editor, string photo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AspNetNews news = new AspNetNews()
                    {
                        Author = ((LSFUser)_userManager.FindByNameAsync(Input.Author).Result).Id,
                        PreviewPhoto = _context.AspNetFiles.FirstOrDefault(p => p.Title == photo).Id,
                        Blocked = false,
                        Date = DateTime.Now,
                        Description = editor,
                        Header = Input.Header,
                        Likes = 0,
                        PreviewText = Input.PreviewText,
                        Share = 0,
                        Url = Input.Url,
                        Watching = 0,
                        
                    };
                    _context.AspNetNews.Add(news);
                    _context.SaveChanges();
                    
                    StatusMessage = "Новость успешно добавлена на сайт!";
                    return RedirectToPage("./Posts");
                }
                catch (Exception ex)
                {
                    ErrorMessage = "Произошла ошибка, новость не добавлена!";
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
