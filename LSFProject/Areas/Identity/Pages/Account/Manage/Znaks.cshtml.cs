using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LSFProject.ViewModelss;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LSFProject.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = "Admin,Moderator")]
    public class ZnaksModel : PageModel
    {
        public LSFProjectContext _context = new LSFProjectContext();
        public List<AspNetFile> znaks;
        [TempData]
        public string StatusMessage { get; set; }

        public ZnaksModel()
        {
            znaks = _context.AspNetFiles.Where(f => f.Type == AspNetFileType.Znak).ToList();
        }

        public void OnGet()
        {
        }

        public IActionResult OnGetDeleteFile(int id)
        {
            if (_context.AspNetFiles.Any(p => p.Id == id) && _context.AspNetTargets.Count(n => n.ImagePath == id) == 0)
            {
                AspNetFile file = _context.AspNetFiles.FirstOrDefault(p => p.Id == id);
                if (System.IO.File.Exists(file.Path))
                    System.IO.File.Delete(file.Path);
                _context.AspNetFiles.Remove(file);
                _context.SaveChanges();
                StatusMessage = "Изображение успешно удалено!";
                return Page();
            }
            StatusMessage = "Ошибка. Изображение не найдено, либо не удалено!";
            return Page();
        }
    }
}
