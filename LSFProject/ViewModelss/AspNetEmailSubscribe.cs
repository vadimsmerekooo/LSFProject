using System.Collections.Generic;

namespace LSFProject.ViewModelss
{
    public class AspNetEmailSubscribe
    {
        public AspNetEmailSubscribe()
        {
            AspNetUsers = new HashSet<AspNetUser>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public bool IsConfirmed { get; set; }
        public string? Code { get; set; }
        public bool? InRoleAdmin { get; set; }

        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}