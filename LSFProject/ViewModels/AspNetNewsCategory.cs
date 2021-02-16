using System;
using System.Collections.Generic;

#nullable disable

namespace LSFProject
{
    public partial class AspNetNewsCategory
    {
        public AspNetNewsCategory()
        {
            AspNetPages = new HashSet<AspNetPage>();
        }

        public int Id { get; set; }
        public string Category { get; set; }

        public virtual ICollection<AspNetPage> AspNetPages { get; set; }
    }
}
