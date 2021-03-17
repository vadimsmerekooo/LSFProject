using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LSFProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Net.Mime.MediaTypeNames;

namespace LSFProject.Areas.Identity.Pages.Account.Manage
{
    public class EditIconUserModel : PageModel
    {
        public UserManager<LSFUser> _userManager;
        public EditIconUserModel(UserManager<LSFUser> userManager)
        {
            _userManager = userManager;
        }
        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            public string Path { get; set; }
        }

        readonly LSFProjectContext _context = new LSFProjectContext();
        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPostAddedPhotoAsync(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                if (!uploadedFile.ContentType.Contains("image"))
                {
                    StatusMessage = "Ошибка. Выбранный файл, не изображение.";
                    return Page();
                }
                using (var ms = new MemoryStream())
                {
                    uploadedFile.CopyTo(ms);
                    byte[] imageByte = ms.ToArray();


                    AspNetIcon icon = new AspNetIcon()
                    {
                        Icon = imageByte,
                        UserId = _userManager.GetUserId(User)
                    };
                    if (_context.AspNetIcons.Any(i => i.UserId == _userManager.GetUserId(User)))
                    {
                        _context.AspNetIcons.FirstOrDefault(i => i.UserId == _userManager.GetUserId(User)).Icon = imageByte;
                        _context.SaveChanges();
                    }
                    else
                    {
                        _context.AspNetIcons.Add(icon);
                        _context.SaveChanges();
                    }
                    _context.AspNetUsers.FirstOrDefault(u => u.Id == _userManager.GetUserId(User)).Icon = _context.AspNetIcons.FirstOrDefault(i => i.UserId == _userManager.GetUserId(User)).Id;
                    _context.SaveChanges();
                }
                StatusMessage = "Аватарка успешно изменена!";
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
