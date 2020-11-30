using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LSFProject.Areas.Identity.Pages.Account.Manage
{
    public class AddedPostModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            public int Id { get; set; }
            [Required]
            public string Header { get; set; }
            [Required]
            public string PreviewText { get; set; }
            [Required]
            public string PreviewPhoto { get; set; }
            [Required]
            public string Url { get; set; }
            [Required]
            public string Description { get; set; }
            public DateTime Date { get; set; }
            [Required]
            public string Author { get; set; }
            public int Blocked { get; set; }
            public int Watching { get; set; }
        }
        
        public void OnPostAsync(string editor, IFormFile inputImage)
        {

        }
    }
}
