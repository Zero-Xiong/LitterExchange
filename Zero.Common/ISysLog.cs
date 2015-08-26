using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zero.Common
{
    public interface ISysLog
    {
        void Exception(Exception error);

        void Performance(string strMessage, params object[] objs);

        void Security(string strMessage, params object[] objs);

        void Audit(string strMessage, params object[] objs);

        void Debug(string strMessage, params object[] objs);

        void Exception(string strMessage, params object[] objs);

        void Info(string strMessage, params object[] objs);
    }
}
