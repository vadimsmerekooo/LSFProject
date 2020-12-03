using System;
using System.Collections.Generic;

#nullable disable

namespace LSFProject.ViewModels
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int NewsId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public bool Answer { get; set; }
    }
}
