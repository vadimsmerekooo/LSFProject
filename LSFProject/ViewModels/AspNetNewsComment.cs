using System;
using System.Collections.Generic;

#nullable disable

namespace LSFProject
{
    public partial class AspNetNewsComment
    {
        public AspNetNewsComment()
        {
            InverseAnswerNavigation = new HashSet<AspNetNewsComment>();
        }

        public int Id { get; set; }
        public int NewsId { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int? Answer { get; set; }

        public virtual AspNetNewsComment AnswerNavigation { get; set; }
        public virtual AspNetNews News { get; set; }
        public virtual AspNetUser User { get; set; }
        public virtual ICollection<AspNetNewsComment> InverseAnswerNavigation { get; set; }
    }
}
