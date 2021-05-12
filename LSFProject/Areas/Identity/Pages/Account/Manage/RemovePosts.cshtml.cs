using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LSFProject.Areas.Identity.Pages.Account.Manage
{
    public class RemovePosts : PageModel
    {
        readonly LSFProjectContext _context = new LSFProjectContext();
        public List<AspNetNews> news;
        public List<AspNetFile> files;
        public List<AspNetNewsComment> comments;
        public RemovePosts()
        {
            news = _context.AspNetNews.Where(news => news.Status == StatusNews.Blocked).ToList();
            files = _context.AspNetFiles.ToList();
            comments = _context.AspNetNewsComments.ToList();
        }
        [TempData]
        public string StatusMessage { get; set; }
        public void OnGet()
        {
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
    }
}
