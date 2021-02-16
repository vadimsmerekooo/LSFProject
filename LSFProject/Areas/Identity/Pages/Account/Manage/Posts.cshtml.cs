using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LSFProject.Areas.Identity.Pages.Account.Manage
{
    public class PostsModel : PageModel
    {
        LSFProjectContext _context = new LSFProjectContext();
        [TempData]
        public string StatusMessage { get; set; }
        [TempData]
        public string ErrorMessage { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnGetBlockedNewsAsync(int newsId)
        {
            try
            {
                if (_context.AspNetNews.Any(@post => post.Id == newsId))
                {
                    _context.AspNetNews.FirstOrDefault(@post => post.Id == newsId).Blocked = true;
                    await _context.SaveChangesAsync();
                }
            }
            catch
            {

            }
            StatusMessage = "Новость заблокирована!";
            return RedirectToPage("./Posts");
        }

        public async Task<IActionResult> OnGetPublishNewsAsync(int newsId)
        {
            if (_context.AspNetNews.Any(newsItem => newsItem.Id == newsId))
            {
                _context.AspNetNews.FirstOrDefault(@post => post.Id == newsId).Blocked = false;
                await _context.SaveChangesAsync();
            }
            StatusMessage = "Новость разблокирована!";
            return RedirectToPage("./Posts");
        }
        public async Task<IActionResult> OnGetDeleteNews(int newsId)
        {
            _context.AspNetNews.Remove(_context.AspNetNews.FirstOrDefault(post => post.Id == newsId));
            foreach (var comments in _context.AspNetNewsComments.Where(comment => comment.NewsId == newsId))
            {
                _context.AspNetNewsComments.Remove(comments);
            }
            _context.SaveChanges();
            StatusMessage = "Новость успешно удалена!";
            return RedirectToPage("./Posts");
        }
    }
}
