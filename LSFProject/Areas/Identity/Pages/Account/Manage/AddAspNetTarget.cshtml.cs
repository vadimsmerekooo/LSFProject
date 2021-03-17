using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LSFProject.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = "Admin, MobileAdmin")]
    public class AddAspNetTargetModel : PageModel
    {
        readonly LSFProjectContext _context = new LSFProjectContext();
        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "Не указано Название!")]
            public string Name { get; set; }
            [Required(ErrorMessage = "Не указано Описание!")]
            public string Description { get; set; }
            public int ImagePath { get; set; }
            [Required(ErrorMessage = "Не указано StatesIds!")]
            public string StatesIds { get; set; }
        }


        public async Task<ActionResult> OnPostCreateAsync(string photo)
        {
            if (ModelState.IsValid)
            {
                AspNetTarget target = new AspNetTarget()
                {
                    Description = Input.Description,
                    ImagePath = _context.AspNetFiles.Where(p => p.Type == ViewModelss.AspNetFileType.Znak).FirstOrDefault(p => p.Title == photo).Id,
                    Name = Input.Name,
                    StatesIds = Input.StatesIds
                };
                _context.AspNetTargets.Add(target);
                _context.SaveChanges();
                StatusMessage = "Target успешно добавлен!";
                return RedirectToPage("./AspNetTarget");
            }
            StatusMessage = "Ошибка Не удалось добавит Target!";
            return RedirectToPage("./AspNetTarget");
        }


        public void OnGet()
        {
        }
    }
}
