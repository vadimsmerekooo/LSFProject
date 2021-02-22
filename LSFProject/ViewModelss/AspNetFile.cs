using System;
using System.Collections.Generic;

#nullable disable

namespace LSFProject
{
    public partial class AspNetFile
    {
        public AspNetFile()
        {
            AspNetNews = new HashSet<AspNetNews>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public bool Photo { get; set; }
        public DateTime DateAdd { get; set; }

        public virtual ICollection<AspNetNews> AspNetNews { get; set; }
    }
}
