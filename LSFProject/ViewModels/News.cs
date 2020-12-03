using System;
using System.Collections.Generic;

#nullable disable

namespace LSFProject.ViewModels
{
    public partial class News
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string PreviewText { get; set; }
        public string PreviewPhoto { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public int? Share { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public bool Blocked { get; set; }
        public int Watching { get; set; }
    }
}
