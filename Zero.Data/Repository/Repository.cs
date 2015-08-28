using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using Zero.Model;
using System.Data.Entity;
using Zero.Data.Infrastructure;

namespace Zero.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        internal DbSet<T> dbSet;

        public IUnitOfWork UnitOfWork { get { return _unitOfWork; } }

        public Repository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException("unitOfWork");
            _unitOfWork = unitOfWork;
            this.dbSet = _unitOfWork.Db.Set<T>();
        }

        public virtual object Add(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual object Delete(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public virtual object Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual bool Exists(object primaryKey)
        {
            return dbSet.Find(primaryKey) == null ? false : true;
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where);
        }

        public virtual IPagedList<T> GetPage<TOrder>(Page page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order)
        {
            var results = dbSet.OrderBy(order).Where(where).GetPage(page);
            var total = dbSet.Count(where);
            return new StaticPagedList<T>(results, page.PageNumber, page.PageSize, total);
        }

        public virtual T Single(object primaryKey)
        {
            return dbSet.Find(primaryKey);
        }

        public virtual T SingleOrDefault(object primaryKey)
        {
            return dbSet.Find(primaryKey);
        }

        public virtual void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
