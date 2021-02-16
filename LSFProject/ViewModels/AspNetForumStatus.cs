using System;
using System.Collections.Generic;

#nullable disable

namespace LSFProject
{
    public partial class AspNetForumStatus
    {
        public AspNetForumStatus()
        {
            AspNetForums = new HashSet<AspNetForum>();
        }

        public int Id { get; set; }
        public string Status { get; set; }

        public virtual ICollection<AspNetForum> AspNetForums { get; set; }
    }
}
