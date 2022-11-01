using DamcoAssignment.Common.Interface;
using DamcoAssignment.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DamcoAssignment.Common.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DamcoPocContext _context = null;
        //   private DbSet<T> table = null;
        public Repository(DamcoPocContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
       
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public T GetByParam(T entity)
        {
            return _context.Set<T>().FirstOrDefault(entity);
        }

        public void Delete(T entity)
        {
            T element = _context.Set<T>().Find(entity);
            _context.Set<T>().Remove(element);
        }
      
    }
}
