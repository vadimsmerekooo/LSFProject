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
    [Authorize(Roles = "Admin")]
    public class EditRolesUserModel : PageModel
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<LSFUser> _userManager;
        public ChangeRoleViewModel modelRole;
        public EditRolesUserModel(RoleManager<IdentityRole> roleManager, UserManager<LSFUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGetAsync(string userId)
        {
            LSFUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                modelRole = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                LSFProjectContext _context = new LSFProjectContext();
                if (_context.AspNetEmailSubscribe.Any(u => u.UserId == user.Id && u.IsConfirmed))
                {
                    string email = _context.AspNetEmailSubscribe.FirstOrDefault(u => u.UserId == userId).Email;
                    string messageText = $"Уважаемый {_context.AspNetUsers.FirstOrDefault(u => u.Id == userId).Email}, для вашего аккаунта измененно ролевое управление доступом.";
                    string message = System.IO.File.ReadAllText("wwwroot/SendMessageUserEmailPage.html")
                        .Replace("MessageText", messageText);
                    EmailSend.SendEmailAsync(email, "Изменение привелегий", message);
                }
                return Page();
            }

            return NotFound();
        }
        public async Task<IActionResult> OnPostEditRolesUserAsync(string userId, List<string> roles)
        {
            // �������� ������������
            LSFUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // ������� ������ ����� ������������
                var userRoles = await _userManager.GetRolesAsync(user);
                // �������� ��� ����
                var allRoles = _roleManager.Roles.ToList();
                // �������� ������ �����, ������� ���� ���������
                var addedRoles = roles.Except(userRoles);
                // �������� ����, ������� ���� �������
                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToPage("./UserList");
            }
            return NotFound();
        }
    }
    public class ChangeRoleViewModel
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public List<IdentityRole> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }
        public ChangeRoleViewModel()
        {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }
    }
}
