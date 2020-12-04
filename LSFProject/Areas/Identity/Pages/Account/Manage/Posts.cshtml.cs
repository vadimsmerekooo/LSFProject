using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LSFProject.Areas.Identity.Pages.Account.Manage
{
    public class PostsModel : PageModel
    {
        LSFProject.ViewModels.LSFProjectContext _context = new ViewModels.LSFProjectContext();
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
                var news = _context.News.Where(@post => post.Id == newsId).ToList();
                if (news.Count != 0)
                {
                    _context.News.FirstOrDefault(@post => post.Id == newsId).Blocked = true;
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
            var news = _context.News.Where(newsItem => newsItem.Id == newsId).ToList();
            if (news.Count != 0)
            {
                _context.News.FirstOrDefault(@post => post.Id == newsId).Blocked = false;
                await _context.SaveChangesAsync();
            }
            StatusMessage = "Новость разблокирована!";
            return RedirectToPage("./Posts");
        }
        public async Task<IActionResult> OnGetDeleteNews(int newsId)
        {
            _context.News.Remove(_context.News.FirstOrDefault(post => post.Id == newsId));
            foreach (var comments in _context.Comments.Where(comment => comment.NewsId == newsId))
            {
                _context.Comments.Remove(comments);
            }
            _context.SaveChanges();
            StatusMessage = "Новость успешно удалена!";
            return RedirectToPage("./Posts");
        }
    }
}
