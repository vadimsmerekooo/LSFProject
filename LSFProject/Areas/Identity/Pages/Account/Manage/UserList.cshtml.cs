using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LSFProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LSFProject.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles ="Admin, Manager")]
    public class UserListModel : PageModel
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<LSFUser> _userManager;
        private LSFProjectContext _context = new LSFProjectContext();
        public List<LSFUser> users;
        [TempData]
        public string StatusMessage { get; set; }
        public UserListModel(RoleManager<IdentityRole> roleManager, UserManager<LSFUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            users = _userManager.Users.ToList();
        }

        public async Task<IActionResult> OnGetDeleteUserAsync(string userId)
        {
            LSFUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                StatusMessage = "Пользователь удален!";
            }
            return RedirectToPage("./UserList");
        }
        public async Task<IActionResult> OnGetLockoutEnabledUser(string userId)
        {
            LSFUser user = await _userManager.FindByIdAsync(userId);
            if(user != null)
            {
                user.LockoutEnd = DateTime.Now.AddYears(200);
                _userManager.ResetAuthenticatorKeyAsync(_userManager.FindByIdAsync(userId).Result);
                await _userManager.UpdateAsync(user);
                StatusMessage = "Пользователь заблокирован!";
            }
            return RedirectToPage("./UserList");
        }
        public async Task<IActionResult> OnGetLockoutEndUser(string userId)
        {
            LSFUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.LockoutEnd = null;
                await _userManager.UpdateAsync(user);
                StatusMessage = "Пользователь разблокирован!";
            }
            return RedirectToPage("./UserList");
        }
    }
}
