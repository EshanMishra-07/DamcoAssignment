using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamcoAssignment.Common.ViewModel
{
    public class ViewModelContent
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
    }
}
