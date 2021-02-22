using System;
using System.Collections.Generic;

#nullable disable

namespace LSFProject
{
    public partial class AspNetForum
    {
        public int Id { get; set; }
        public int Questions { get; set; }
        public int Status { get; set; }

        public virtual AspNetForumQuestion QuestionsNavigation { get; set; }
        public virtual AspNetForumStatus StatusNavigation { get; set; }
    }
}
