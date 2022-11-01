using DamcoAssignment.Common.Interface;
using DamcoAssignment.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DamcoAssignment.Common.Implementation
{
    public class UnitOfWork:IUnitOfWork
    {
        private DamcoPocContext _context;
        public IUsersRepository users { get; private set; }
       
       public IContentRepository contentRepository { get; private set; }
        public UnitOfWork(DamcoPocContext context)
        {
            _context = context;
            users = new UsersRepository(_context);
            contentRepository=new ContentRepository(_context);
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

          
    }
}
