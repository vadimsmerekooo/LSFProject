using Microsoft.AspNetCore.Mvc.RazorPages;
using  System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LSFProject.Areas.Identity.Pages.Account.Manage
{
    public class ModerationPosts : PageModel
    {
        readonly LSFProjectContext _context = new LSFProjectContext();
        public List<AspNetNews> news;
        public List<AspNetFile> files;
        public List<AspNetNewsComment> comments;
        public ModerationPosts()
        {
            news = _context.AspNetNews.Where(news => news.Status == StatusNews.Moderation).ToList();
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
                _context.AspNetNews.FirstOrDefault(post => post.Id == newsId).Status = StatusNews.Publish;
                await _context.SaveChangesAsync();
            }
            StatusMessage = "Новость успешно опубликована!";
            
            var link = Url.Action(nameof(LSFProject.Controllers.HomeController.NewsDetails), "Home",
                new {url = _context.AspNetNews.FirstOrDefault(post => post.Id == newsId).Url}, Request.Scheme,
                Request.Host.ToString());
            
            EmailSend.NewsletterSendEmailAsync(link);
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
            StatusMessage = "Новость успешно удалена!";
            return RedirectToPage("./Posts");
        }
    }
}