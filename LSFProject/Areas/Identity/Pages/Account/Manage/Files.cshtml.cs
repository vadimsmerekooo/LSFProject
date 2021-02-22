using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LSFProject.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = "Admin,Moderator")]
    public class FilesModel : PageModel
    {
        public LSFProjectContext _context = new LSFProjectContext();
        public List<AspNetFile> files;
        [TempData]
        public string StatusMessage { get; set; }

        public FilesModel()
        {
            files = _context.AspNetFiles.ToList();
        }

        public void OnGet()
        {
        }
            
        public IActionResult OnGetDeleteFile(int id)
        {
            if (_context.AspNetFiles.Any(p => p.Id == id) && _context.AspNetNews.Count(n => n.PreviewPhoto == id) == 0)
            {
                _context.AspNetFiles.Remove(_context.AspNetFiles.First(p => p.Id == id));
                _context.SaveChanges();
                StatusMessage = "Изображение успешно удалено!";
                return Page();
            }
            StatusMessage = "Ошибка. Изображение не найдено, либо не удалено!";
            return Page();
        }
    }
}
