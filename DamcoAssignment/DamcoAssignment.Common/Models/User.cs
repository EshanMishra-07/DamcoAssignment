using System;
using System.Collections.Generic;

namespace DamcoAssignment.Common.Models
{
    public partial class User
    {
        public User()
        {
            ContentBlogs = new HashSet<ContentBlog>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime? Doc { get; set; }
        public DateTime? Dol { get; set; }
        public string Roles { get; set; }
        public bool? IsActive { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime? ExpiryTime { get; set; }

        public virtual ICollection<ContentBlog> ContentBlogs { get; set; }
    }
}
