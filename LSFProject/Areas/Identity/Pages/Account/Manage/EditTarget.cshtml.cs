using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LSFProject.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = "Admin, MobileAdmin")]
    public class EditTargetModel : PageModel
    {
        private LSFProjectContext _context = new LSFProjectContext();
        public AspNetFile file = new AspNetFile();
        [BindProperty]
        public InputModel Input { get; set; }
        [TempData]
        public string StatusMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "Не указано имя!")]
            public string Name { get; set; }
            [Required(ErrorMessage = "Не указано описание!")]
            public string Description { get; set; }
            public int ImagePath { get; set; }
            [Required(ErrorMessage = "Не указано StatesIds!")]
            public string StatesIds { get; set; }
            public string FileTitle { get; set; }

        }

        public void OnGet(int id)
        {
            if (_context.AspNetTargets.Any(t => t.Id == id))
            {
                AspNetTarget target = _context.AspNetTargets.FirstOrDefault(t => t.Id == id);
                string title = _context.AspNetFiles.FirstOrDefault(p => p.Id == target.ImagePath).Title;
                Input = new InputModel()
                {
                    Id = target.Id,
                    Name = target.Name,
                    Description = target.Description,
                    ImagePath = target.ImagePath,
                    StatesIds = target.StatesIds,
                    FileTitle = title
                };
            }

        }

        public ActionResult OnPostChangeTarget(string photo)
        {
            if (ModelState.IsValid && _context.AspNetFiles.Any(p => p.Title == photo))
            {
                try
                {
                    AspNetTarget target = _context.AspNetTargets.FirstOrDefault(t => t.Id == Input.Id);

                    target.Description = Input.Description;
                    target.ImagePath = _context.AspNetFiles.First(p => p.Title == photo).Id;
                    target.Name = Input.Name;
                    target.StatesIds = Input.StatesIds;
                    _context.AspNetTargets.Update(target);
                    _context.SaveChanges();
                    StatusMessage = "Target успешно обновлен!";
                    return RedirectToPage("./AspNetTargets");
                }
                catch
                {
                    StatusMessage = "Ошибка Не удалось обновить Target!";
                    return RedirectToPage("./AspNetTargets");
                }
            }
            StatusMessage = "Ошибка Не удалось обновить Target!";
            return RedirectToPage("./AspNetTargets");
        }
    }

}
