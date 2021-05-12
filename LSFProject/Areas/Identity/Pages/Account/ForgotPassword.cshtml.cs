using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using LSFProject.Areas.Identity.Data;

namespace LSFProject.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<LSFUser> _userManager;

        public ForgotPasswordModel(UserManager<LSFUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        [TempData]
        public string StatusMessage { get; set; }


        public class InputModel
        {
            [Required]
            public string Login { get; set; }
            [Required]
            public string Password { get; set; }
            [Required]
            public string SecurityPassword { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(Input.Login);
                if (user == null)
                {
                    StatusMessage = $"Ошибка Пользователь {Input.Login} не найден!";
                    return Page();
                }
                if(Input.SecurityPassword != user.Id.Substring(0, 4).ToString())
                {
                    StatusMessage = "Ошибка Не верно заполнены поля!";
                    return Page();
                }

                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, Input.Password + "!");
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToPage("./Login");
                }
                StatusMessage = "Ошибка Не удалось сменить пароль!";
                return Page();
            }
            StatusMessage = "Ошибка Заполните все поля!";
            return Page();
        }
    }
}
