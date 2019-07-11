using Microsoft.EntityFrameworkCore;
using NorthwindDemoBackend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NorthwindDemoBackend.Models.Repositories
{
    public class GenericRepository<T> : IRepository<T>
        where T : class
    {
        private readonly NorthwindContext _context;

        public GenericRepository(NorthwindContext context)
        {
            _context = context;
        }

        public DbSet<T> _objectset;
        public DbSet<T> ObjectSet
        {
            get
            {
                if (_objectset == null)
                {
                    _objectset = _context.Set<T>();
                }
                return _objectset;
            }
        }

        public IQueryable<T> All()
        {
            return ObjectSet.AsQueryable();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return ObjectSet.Where(expression);
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return ObjectSet.Any(expression);
        }

        public void Add(T entity)
        {
            ObjectSet.Add(entity);
        }

        public void Delete(T entity)
        {
            ObjectSet.Remove(entity);
        }

        public void AddRange(List<T> entities)
        {
            ObjectSet.AddRange(entities);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
