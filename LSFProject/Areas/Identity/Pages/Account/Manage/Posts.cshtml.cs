using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LSFProject.Areas.Identity.Pages.Account.Manage
{
    public class PostsModel : PageModel
    {
        readonly LSFProjectContext _context = new LSFProjectContext();
        [TempData]
        public string StatusMessage { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnGetBlockedNewsAsync(int newsId)
        {
            try
            {
                if (_context.AspNetNews.Any(@post => post.Id == newsId))
                {
                    _context.AspNetNews.FirstOrDefault(@post => post.Id == newsId).Status = StatusNews.Blocked;
                    await _context.SaveChangesAsync();
                }
            }
            catch
            {

            }
            StatusMessage = "������� �������������!";
            return RedirectToPage("./Posts");
        }

        public async Task<IActionResult> OnGetPublishNewsAsync(int newsId)
        {
            if (_context.AspNetNews.Any(newsItem => newsItem.Id == newsId))
            {
                _context.AspNetNews.FirstOrDefault(@post => post.Id == newsId).Status = StatusNews.Publish;
                await _context.SaveChangesAsync();
            }
            StatusMessage = "������� ��������������!";
            return RedirectToPage("./Posts");
        }
        public IActionResult OnGetDeleteNews(int newsId)
        {
            _context.AspNetNews.Remove(_context.AspNetNews.FirstOrDefault(post => post.Id == newsId));
            foreach (var comments in _context.AspNetNewsComments.Where(comment => comment.NewsId == newsId))
            {
                _context.AspNetNewsComments.Remove(comments);
            }
            _context.SaveChanges();
            StatusMessage = "������� ������� �������!";
            return RedirectToPage("./Posts");
        }
        public async Task<IActionResult> OnGetGoToModerationNews(int newsId)
        {
            if (_context.AspNetNews.Any(newsItem => newsItem.Id == newsId))
            {
                _context.AspNetNews.FirstOrDefault(@post => post.Id == newsId).Status = StatusNews.Moderation;
                await _context.SaveChangesAsync();
            }
            StatusMessage = "������� ���������� �� ���������!";
            return RedirectToPage("./Posts");
        }
    }
}
