using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamcoAssignment.Common.ViewModel
{
    public class ViewModelUser
    {
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

    }
}
