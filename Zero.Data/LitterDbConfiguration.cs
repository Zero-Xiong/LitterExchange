using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Data
{
    public class LitterDbConfiguration : DbConfiguration
    {
        public LitterDbConfiguration()
        {
            DbInterception.Add(new LitterDbInterceptorLogging());
            DbInterception.Add(new LitterDbInterceptorTransientError());
        }
    }
}
