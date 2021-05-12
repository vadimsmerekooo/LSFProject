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
        public RoleManager<IdentityRole> _roleManager;
        public UserManager<LSFUser> _userManager;
        private LSFProjectContext _context = new LSFProjectContext();
        public List<AspNetUser> users;
        [TempData] public string StatusMessage { get; set; }

        public UserListModel(RoleManager<IdentityRole> roleManager, UserManager<LSFUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            users = _context.AspNetUsers.ToList();
        }

        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> OnGetLockoutEnabledUser(string userId)
        {
            try
            {
                if (_context.AspNetUsers.Any(u => u.Id == userId) && User.IsInRole("Admin"))
                {
                    _context.AspNetUsers.FirstOrDefault(u => u.Id == userId).LockoutEnd = DateTime.Now.AddYears(200);
                    _context.SaveChanges();
                    _userManager.ResetAuthenticatorKeyAsync(_userManager.FindByIdAsync(userId).Result);
                    StatusMessage = "Пользователь заблокирован!";

                    string email = string.Empty;
                    if (_context.AspNetEmailSubscribe.Any(u => u.UserId == userId && u.IsConfirmed))
                    {
                        email = _context.AspNetEmailSubscribe.FirstOrDefault(u => u.UserId == userId).Email;
                        
                        EmailSend.SendEmailAsync(email, "Ваш аккаунт заблокирован!", System.IO.File.ReadAllText("wwwroot/SendMessageUserLockoutEmailPage.html"));
                    }
                    
                }

                return RedirectToPage("./UserList");
            }
            catch
            {
                StatusMessage = "Ошибка. Пользователь не заблокирован!";
                return RedirectToPage("./UserList");
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> OnGetLockoutEndUser(string userId)
        {

            LSFUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                _context.AspNetUsers.FirstOrDefault(u => u.Id == userId).LockoutEnd = null;
                _context.SaveChanges();
                StatusMessage = "Пользователь разблокирован!";
                
                string email = string.Empty;
                if (_context.AspNetEmailSubscribe.Any(u => u.UserId == userId && u.IsConfirmed))
                {
                    email = _context.AspNetEmailSubscribe.FirstOrDefault(u => u.UserId == userId).Email;
                        
                    EmailSend.SendEmailAsync(email, "Ваш аккаунт разблокирован!", System.IO.File.ReadAllText("wwwroot/SendMessageUserLockoutEndEmailPage.html"));
                }
            }

            return RedirectToPage("./UserList");
        }
    }
}