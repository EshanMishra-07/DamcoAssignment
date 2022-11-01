using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamcoAssignment.Common.ViewModel
{
    public class ViewModelContentUserwise
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
      
        public string UserName { get; set; }
      
        public DateTime? Dol { get; set; }
        public string Roles { get; set; }
        public bool? IsActive { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
