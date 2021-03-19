using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LSFProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LSFProject.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LockoutModel : PageModel
    {
        UserManager<LSFUser> _userManager;
        public TimeSpan? lockoutEndTime;
        public LockoutModel(UserManager<LSFUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGetAsync(string userId)
        {
            try
            {
                LSFUser user = await _userManager.FindByIdAsync(userId);
                if (user != null)
                {
                    lockoutEndTime = user.LockoutEnd - DateTime.Now;
                }
                return Page();
            }
            catch
            {
                return RedirectToPage("./Login");
            }
        }
    }
}
