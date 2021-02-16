using System;
using System.Collections.Generic;

#nullable disable

namespace LSFProject
{
    public partial class AspNetForumQuestion
    {
        public AspNetForumQuestion()
        {
            AspNetForumAnswers = new HashSet<AspNetForumAnswer>();
            AspNetForums = new HashSet<AspNetForum>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime DateCreate { get; set; }

        public virtual AspNetUser AuthorNavigation { get; set; }
        public virtual ICollection<AspNetForumAnswer> AspNetForumAnswers { get; set; }
        public virtual ICollection<AspNetForum> AspNetForums { get; set; }
    }
}
