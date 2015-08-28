using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Zero.Data.Infrastructure;
using Zero.Model;

namespace Zero.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        IUnitOfWork UnitOfWork { get; }

        T Single(object primaryKey);
        T SingleOrDefault(object primaryKey);

        bool Exists(object primaryKey);

        object Add(T entity);

        void Update(T entity);

        object Delete(T entity);
        object Delete(Expression<Func<T, bool>> where);

        IEnumerable<T> GetAll();

        T Get(Expression<Func<T, bool>> where);

        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

        IPagedList<T> GetPage<TOrder>(Page page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order);
    }
}
