using System;
using System.Collections.Generic;

#nullable disable

namespace LSFProject
{
    public partial class AspNetPage
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string Url { get; set; }
        public int Category { get; set; }
        public DateTime DateCreate { get; set; }

        public virtual AspNetNewsCategory CategoryNavigation { get; set; }
    }
}
