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
    [Authorize]
    public class UserInfoModel : PageModel
    {
        public LSFProjectContext _context = new LSFProjectContext();
        public AspNetUser user;
        public byte[] Image;
        public UserManager<LSFUser> _userManager;
        RoleManager<IdentityRole> _roleManager;
        public List<LSFUser> users;

        public UserInfoModel(RoleManager<IdentityRole> roleManager, UserManager<LSFUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            users = _userManager.Users.ToList();
        }

        public void OnGet(string userId)
        {
            user = _context.AspNetUsers.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                NotFound();
            if (_context.AspNetIcons.Any(i => i.Id == user.Icon))
                Image = _context.AspNetIcons.FirstOrDefault(i => i.Id == user.Icon).Icon;
        }

        [TempData] public string StatusMessage { get; set; }


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
                    StatusMessage = "Пользователь заблокирован! ";

                    string email = string.Empty;
                    if (_context.AspNetEmailSubscribe.Any(u => u.UserId == userId && u.IsConfirmed))
                    {
                        email = _context.AspNetEmailSubscribe.FirstOrDefault(u => u.UserId == userId).Email;

                        EmailSend.SendEmailAsync(email, "Ваш аккаунт заблокирован!",
                            System.IO.File.ReadAllText("wwwroot/SendMessageUserLockoutEmailPage.html"));
                        StatusMessage = "Сообщение пользователю отправлено.";
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
                StatusMessage = "Пользователь разблокирован! ";

                string email = string.Empty;
                if (_context.AspNetEmailSubscribe.Any(u => u.UserId == userId && u.IsConfirmed))
                {
                    email = _context.AspNetEmailSubscribe.FirstOrDefault(u => u.UserId == userId).Email;

                    EmailSend.SendEmailAsync(email, "Ваш аккаунт разблокирован!",
                        System.IO.File.ReadAllText("wwwroot/SendMessageUserLockoutEndEmailPage.html"));
                    StatusMessage += "Сообщение отправлено пользователю.";
                }
            }

            return RedirectToPage("./UserList");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult OnPostSendMessageUser(string userId, string messageText)
        {
            string email = String.Empty;
            if (_context.AspNetEmailSubscribe.Any(e => e.UserId == userId && e.IsConfirmed))
            {
                email = _context.AspNetEmailSubscribe.FirstOrDefault(e => e.UserId == userId).Email;
            }
            else
            {
                StatusMessage = "Ошибка. Email адрес пользователя не найден.";
                return RedirectToPage("UserInfo", new {userId = userId});
            }

            string subject = "Письмо от администрации сайта";
            string message = System.IO.File.ReadAllText("wwwroot/SendMessageUserEmailPage.html");


            EmailSend.SendEmailAsync(email,
                subject,
                message.Replace("UserEmail", email).Replace("MessageText", messageText));
            StatusMessage = "Сообщение отправлено.";
            return RedirectToPage("UserInfo", new {userId = userId});
        }

        public IActionResult OnGetUnblockedTestForUser(string userId, int testId)
        {
            if (_context.AspNetTestResults.Any(t => t.TestId == testId && t.UserId == userId && t.IsBlocked))
            {
                _context.AspNetTestResults.FirstOrDefault(t => t.UserId == userId && t.TestId == t.TestId).IsBlocked =
                    false;
                _context.SaveChanges();
                StatusMessage = "Тест для пользователя разблокирован. ";
                if (_context.AspNetEmailSubscribe.Any(e => e.UserId == userId))
                {
                    string linkTest = string.Empty;
                    string test = String.Empty;
                    switch (testId)
                    {
                        case 1:
                            test = "Островок безопасности";
                            linkTest = "<a asp-controller=\"Home\" asp-action=\"RazdelOBJ\" asp-route-linkRazdel=\"child/test\" asp-route-razdelName=\"child\">Островок безопасности</a>";
                            break;
                        case 2: break;
                        case 3: break;
                        
                    }

                    var email = _context.AspNetEmailSubscribe.FirstOrDefault(e => e.UserId == userId).Email;
                    string subject = "Письмо от администрации сайта";
                    string message = System.IO.File.ReadAllText("wwwroot/SendMessageUserEmailPage.html");
                    string messageText = $"Уважаемый {_userManager.FindByIdAsync(userId).Result.Email}, тест {linkTest} теперь доступен для Вас.";


                    EmailSend.SendEmailAsync(email,
                        subject,
                        message.Replace("UserEmail", email).Replace("MessageText", messageText));
                    StatusMessage += " Сообщение пользователю отправлено.";
                }

                return RedirectToPage("UserInfo", new {userId = userId});
            }

            StatusMessage = "Ошибка. Что-то пошло не так... :(";
            return RedirectToPage("UserInfo", new {userId = userId});
        }
    }
}