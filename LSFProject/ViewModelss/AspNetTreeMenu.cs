using System;
using System.Collections.Generic;

#nullable disable

namespace LSFProject
{
    public partial class AspNetTreeMenu
    {
        public AspNetTreeMenu()
        {
            InverseParentNavigation = new HashSet<AspNetTreeMenu>();
        }

        public int Id { get; set; }
        public string Item { get; set; }
        public bool Main { get; set; }
        public int? Parent { get; set; }
        public string Url { get; set; }

        public virtual AspNetTreeMenu ParentNavigation { get; set; }
        public virtual ICollection<AspNetTreeMenu> InverseParentNavigation { get; set; }
    }
}
