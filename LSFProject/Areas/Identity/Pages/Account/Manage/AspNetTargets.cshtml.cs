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
    [Authorize(Roles ="Admin, MobileAdmin")]
    public class AspNetTargetsModel : PageModel
    {
        readonly LSFProjectContext _context = new LSFProjectContext();
        public List<AspNetTarget> targets;
        public List<AspNetFile> files;
        public AspNetTargetsModel()
        {
            targets = _context.AspNetTargets.OrderByDescending(t => t.Id).ToList();
            files = _context.AspNetFiles.Where(f => f.Type == AspNetFileType.Znak).OrderByDescending(t => t.Id).ToList();
        }
        [TempData]
        public string StatusMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
        public void OnGet()
        {
        }
        
        public async Task<ActionResult> OnGetDeleteAsync(int id)
        {
            if (id == 0 || !_context.AspNetTargets.Any(t => t.Id == id))
            {
                StatusMessage = "Ошибка. Target не найден! Возможно он был уже удален!";
                return Page();
            }

            if (_context.AspNetTargets.Any(t => t.Id == id))
            {
                _context.AspNetTargets.Remove(targets.FirstOrDefault(t => t.Id == id));
                await _context.SaveChangesAsync();
            }
            StatusMessage = "Target успешно удален!";
            return Page();
        }
    }
}
