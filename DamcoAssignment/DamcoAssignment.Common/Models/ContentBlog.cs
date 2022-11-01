using System;
using System.Collections.Generic;

namespace DamcoAssignment.Common.Models
{
    public partial class ContentBlog
    {
        public int ContentId { get; set; }
        public string Title { get; set; }
        public string BlogContent { get; set; }
        public int? UserId { get; set; }
        public DateTime? Doc { get; set; }
        public string Topic { get; set; }
        public string Template { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? Dod { get; set; }

        public virtual User User { get; set; }
    }
}
