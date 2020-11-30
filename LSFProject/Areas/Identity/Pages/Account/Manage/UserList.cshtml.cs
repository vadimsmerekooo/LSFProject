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
        public List<LSFUser> users;
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
            }
            return RedirectToPage("./UserList");
        }
        public async Task<IActionResult> OnGetLockoutEnabledUser(string userId)
        {
            LSFUser user = await _userManager.FindByIdAsync(userId);
            if(user != null)
            {
                user.LockoutEnd = DateTime.Now.AddYears(200);
                await _userManager.UpdateAsync(user);
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
            }
            return RedirectToPage("./UserList");
        }
    }
}
