using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LSFProject.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = "Admin,Moderator")]
    public class UploadPhotoModel : PageModel
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

        public UploadPhotoModel(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        readonly LSFProjectContext _context = new LSFProjectContext();
        readonly IWebHostEnvironment _appEnvironment;

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

                string path = Path.Combine(_appEnvironment.WebRootPath, Path.GetFileName(uploadedFile.FileName));

                if (System.IO.File.Exists(_appEnvironment.WebRootPath + path))
                    path = Path.Combine(_appEnvironment.WebRootPath, Path.GetFileName(uploadedFile.FileName), uploadedFile.FileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                AspNetFile photo = new AspNetFile()
                {
                    Path = path,
                    Photo = true,
                    Title = Input.Title,
                    DateAdd = DateTime.Now
                };
                _context.AspNetFiles.Add(photo);
                _context.SaveChanges();
                StatusMessage = "Фото успешно загружено!";
                return RedirectToPage("./Files");
            }
            return Page();
        }

    }
}
