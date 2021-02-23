using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using LSFProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace LSFProject.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<LSFUser> _signInManager;
        private readonly UserManager<LSFUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<LSFUser> userManager,
            SignInManager<LSFUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Поле Имя не заполнено!")]
            [StringLength(30, MinimumLength = 2, ErrorMessage = "Мин длинна имя 2 символов")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Поле Логин не заполнено!")]
            [Display(Name = "Логин")]
            public string Login { get; set; }

            [Required(ErrorMessage = "Поле Пароль не заполнено!")]
            [StringLength(100, ErrorMessage = "Мин длинна пароля 8 символов, макс 100", MinimumLength = 8)]
            [Display(Name = "Пароль")]
            public string Password { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new LSFUser { UserName = Input.Name, Email = Input.Login, EmailConfirmed = true };
                var result = await _userManager.CreateAsync(user, Input.Password + "!");
                if (result.Succeeded)
                {
                    LSFUser user1 = await _userManager.FindByIdAsync(_userManager.Users.Where(x => x.Email == user.Email).Select(x => x.Id).ToList()[0]);
                    List<string> roles = new List<string>() { "user" };
                    if (user1 != null)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user1);
                        var allRoles = _roleManager.Roles.ToList();
                        var addedRoles = roles.Except(userRoles);
                        var removedRoles = userRoles.Except(roles);
                    
                        await _userManager.AddToRolesAsync(user1, addedRoles);
                    
                        await _userManager.RemoveFromRolesAsync(user1, removedRoles);
                    }
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
