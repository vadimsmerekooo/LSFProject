using System;
using System.Collections.Generic;

#nullable disable

namespace LSFProject
{
    public partial class AspNetForumAnswer
    {
        public AspNetForumAnswer()
        {
            InverseAnswer = new HashSet<AspNetForumAnswer>();
        }

        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Question { get; set; }
        public int? AnswerId { get; set; }

        public virtual AspNetForumAnswer Answer { get; set; }
        public virtual AspNetUser AuthorNavigation { get; set; }
        public virtual AspNetForumQuestion QuestionNavigation { get; set; }
        public virtual ICollection<AspNetForumAnswer> InverseAnswer { get; set; }
    }
}
