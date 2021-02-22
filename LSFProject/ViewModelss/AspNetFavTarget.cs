using System;
using System.Collections.Generic;

#nullable disable

namespace LSFProject
{
    public partial class AspNetFavTarget
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? TargetId { get; set; }

        public virtual AspNetTarget Target { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
