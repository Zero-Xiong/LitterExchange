using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        DbContext Db { get; }
    }
}
