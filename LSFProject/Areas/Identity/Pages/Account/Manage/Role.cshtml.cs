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
    public class RoleModel : PageModel
    {
        RoleManager<IdentityRole> _roleManager;
        UserManager<LSFUser> _userManager;
        public List<IdentityRole> roles;
        public RoleModel(RoleManager<IdentityRole> roleManager, UserManager<LSFUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            roles = _roleManager.Roles.ToList();
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostDeleteRoleAsync(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToPage("./Role");
        }
    }
}
