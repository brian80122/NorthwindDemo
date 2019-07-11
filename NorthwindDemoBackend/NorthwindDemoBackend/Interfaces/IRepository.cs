using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NorthwindDemoBackend.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        IQueryable<T> All();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        bool Any(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(List<T> entities);
        void Delete(T entity);
        void SaveChanges();
    }
}
