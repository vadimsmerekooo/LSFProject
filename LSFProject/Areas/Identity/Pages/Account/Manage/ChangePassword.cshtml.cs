using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LSFProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LSFProject.Areas.Identity.Pages.Account.Manage
{
    public class ChangePasswordModel : PageModel
    {
        private readonly UserManager<LSFUser> _userManager;
        private readonly SignInManager<LSFUser> _signInManager;

        public ChangePasswordModel(
            UserManager<LSFUser> userManager,
            SignInManager<LSFUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Пароль")]
            [DataType(DataType.Password)]
            public string OldPassword { get; set; }

            [Required]
            [StringLength(30, MinimumLength = 8, ErrorMessage = "Мин длинна пароля 8 символов, макс 100")]
            [DataType(DataType.Password)]
            [Display(Name = "Новый пароль")]
            public string NewPassword { get; set; }

            [Display(Name = "Подтвердите новый пароль")]
            [Compare("NewPassword", ErrorMessage = "Пароли не совпадают.")]
            [DataType(DataType.Password)]
            public string ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("./Login");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, Input.OldPassword + "!", Input.NewPassword + "!");
            if (!changePasswordResult.Succeeded)
            {
                StatusMessage = "Ошибка Не верный старый пароль!";
                return Page();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Ваш пароль успешно изменен!";

            return Page();
        }
    }
}
