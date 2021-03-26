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
    [Authorize(Roles = "Admin, Manager")]
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
            try
            {
                if (_context.AspNetUsers.Any(u => u.Id == userId))
                {
                    _context.AspNetUsers.FirstOrDefault(u => u.Id == userId).LockoutEnd = DateTime.Now.AddYears(200);
                    _context.SaveChanges();
                    await _userManager.ResetAuthenticatorKeyAsync(_userManager.FindByIdAsync(userId).Result);
                    StatusMessage = "Пользователь заблокирован!";
                }
                return RedirectToPage("./UserList");
            }
            catch
            {
                StatusMessage = "Ошибка. Пользователь не заблокирован!";
                return RedirectToPage("./UserList");
            }
        }
        public async Task<IActionResult> OnGetLockoutEndUser(string userId)
        {
            LSFUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                _context.AspNetUsers.FirstOrDefault(u => u.Id == userId).LockoutEnd = null;
                _context.SaveChanges();
                StatusMessage = "Пользователь разблокирован!";
            }
            return RedirectToPage("./UserList");
        }
    }
}
