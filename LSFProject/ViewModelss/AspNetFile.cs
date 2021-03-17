using System;
using System.Collections.Generic;
using LSFProject.ViewModelss;

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
        public DateTime DateAdd { get; set; }
        public AspNetFileType Type { get; set; }

        public virtual ICollection<AspNetNews> AspNetNews { get; set; }
        public virtual ICollection<AspNetTarget> AspNetTargets { get; set; }
    }
}
