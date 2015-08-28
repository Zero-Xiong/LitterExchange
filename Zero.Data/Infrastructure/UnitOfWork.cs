using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Zero.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LitterDbContext _db;

        public UnitOfWork()
        {
            _db = new LitterDbContext();
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            if(_db != null)
                _db.Dispose();
        }

        public DbContext Db
        {
            get { return _db ; }
        }



    }
}
