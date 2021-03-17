using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LSFProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LSFProject.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        public LSFProjectContext _context = new LSFProjectContext();
        public AspNetUser user;
        public byte[] Image;
        public UserManager<LSFUser> _userManager;

        public IndexModel(UserManager<LSFUser> userManager)
        {
            _userManager = userManager;
        }
        public void OnGet()
        {
            user = _context.AspNetUsers.FirstOrDefault(u => u.Id == _userManager.GetUserId(User));
            if (_context.AspNetIcons.Any(i => i.Id == user.Icon))
                Image = _context.AspNetIcons.FirstOrDefault(i => i.Id == user.Icon).Icon;
        }
    }
}
