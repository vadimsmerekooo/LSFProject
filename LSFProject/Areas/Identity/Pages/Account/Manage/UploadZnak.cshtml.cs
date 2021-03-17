using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LSFProject.ViewModelss;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LSFProject.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = "Admin,Moderator")]
    public class UploadZnakModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            public string Path { get; set; }
            [Required(ErrorMessage = "Напишите описание")]
            public string Title { get; set; }
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

                string path = Path.GetFileName(uploadedFile.FileName);

                if (System.IO.File.Exists("wwwroot/img/znaks/" + path))
                    path = new Random().Next(99999) + Path.GetFileName(uploadedFile.FileName);

                using (var fileStream = new FileStream("wwwroot/img/znaks/" + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                AspNetFile photo = new AspNetFile()
                {
                    Path = "img/znaks/" + path,
                    Title = Input.Title,
                    Type = AspNetFileType.Znak,
                    DateAdd = DateTime.Now
                };
                _context.AspNetFiles.Add(photo);
                _context.SaveChanges();
                StatusMessage = "Знак успешно загружен!";
                return RedirectToPage("./Znaks");
            }
            return Page();
        }
    }
}
