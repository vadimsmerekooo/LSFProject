using System.ComponentModel.DataAnnotations;
using LSFProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LSFProject.Areas.Identity.Pages.Account.Manage
{
    public class InfoSecurePass : PageModel
    {private readonly UserManager<LSFUser> _userManager;
        private readonly SignInManager<LSFUser> _signInManager;

        public InfoSecurePass(
            UserManager<LSFUser> userManager,
            SignInManager<LSFUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        
    }
}