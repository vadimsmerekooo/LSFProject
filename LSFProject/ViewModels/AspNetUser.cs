using System;
using System.Collections.Generic;

#nullable disable

namespace LSFProject
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspNetForumAnswers = new HashSet<AspNetForumAnswer>();
            AspNetForumQuestions = new HashSet<AspNetForumQuestion>();
            AspNetNews = new HashSet<AspNetNews>();
            AspNetNewsComments = new HashSet<AspNetNewsComment>();
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserRoles = new HashSet<AspNetUserRole>();
            AspNetUserTokens = new HashSet<AspNetUserToken>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual ICollection<AspNetForumAnswer> AspNetForumAnswers { get; set; }
        public virtual ICollection<AspNetForumQuestion> AspNetForumQuestions { get; set; }
        public virtual ICollection<AspNetNews> AspNetNews { get; set; }
        public virtual ICollection<AspNetNewsComment> AspNetNewsComments { get; set; }
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }
    }
}
