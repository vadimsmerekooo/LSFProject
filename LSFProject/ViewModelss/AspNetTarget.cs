using System;
using System.Collections.Generic;

#nullable disable

namespace LSFProject
{
    public partial class AspNetTarget
    {
        public AspNetTarget()
        {
            AspNetFavTargets = new HashSet<AspNetFavTarget>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ImagePath { get; set; }
        public string StatesIds { get; set; }

        public virtual AspNetFile ImagePathNavigation { get; set; }
        public virtual ICollection<AspNetFavTarget> AspNetFavTargets { get; set; }
    }
}
