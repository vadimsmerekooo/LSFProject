using System.Collections.Generic;

namespace LSFProject.Models
{
    public class SearchViewModel
    {
        public SearchViewModel()
        {
                
        }
        public string SearchQuery { get; set; }
        public List<AspNetUser> Users { get; set; }
        public List<AspNetNews> News { get; set; }
        public List<AspNetNewsCategory> Categoryes { get; set; }
    }
}