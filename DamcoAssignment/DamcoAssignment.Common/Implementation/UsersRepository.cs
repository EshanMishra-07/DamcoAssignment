using DamcoAssignment.Common.Interface;
using DamcoAssignment.Common.Models;
using DamcoAssignment.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamcoAssignment.Common.Implementation
{
    public class UsersRepository:Repository<User>,IUsersRepository
    {
        public UsersRepository(DamcoPocContext context) : base(context)
        {
        }
        //public IEnumerable<Developer> GetPopularDevelopers(int count)
        //{
        //    return _context.Developers.OrderByDescending(d => d.Followers).Take(count).ToList();
        //}

        //public void Add(ViewModelUser viewModelUser)
        //{
        //    context
        //}
    }
}
