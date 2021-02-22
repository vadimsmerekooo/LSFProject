using System;
using System.Collections.Generic;

#nullable disable

namespace LSFProject
{
    public partial class AspNetIcon
    {
        public AspNetIcon()
        {
            AspNetUsers = new HashSet<AspNetUser>();
        }

        public int Id { get; set; }
        public byte[] Icon { get; set; }

        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
