using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Zero.Common
{
    public class SysLog : ISysLog
    {
        private ILog logger = null;

        #region Log output marker

        private const string PERFORMANCE = "[Performance]";
        private const string SECURITY = "[Security]";
        private const string AUDIT = "[Audit      ]";
        private const string EXCPETION = "[Exception   ]";
        private const string DEBUG = "[Debug      ]";
        private const string GENERAL = "[General    ]";
        private const string SERVER = "[Server     ]";
        private const string EMPTY = "NO-CLASS";

        #endregion Log output marker

        #region Private ctor

        private SysLog(Type _type)
        {
            logger = LogManager.GetLogger(_type);
        }

        private SysLog(String _type)
        {
            if (String.IsNullOrEmpty(_type))
            {
                _type = EMPTY;
            }
            logger = LogManager.GetLogger(_type);
        }

        #endregion

        #region Static Methods to get an Instance of a Logger

        public static ISysLog GetLogger(Type _type)
        {
            return new SysLog(_type);
        }

        public static ISysLog GetLogger(String _type)
        {
            return new SysLog(_type);
        }

        #endregion Static Methods to get an Instance of a Logger

        static SysLog()
        {
            if (Assembly.GetEntryAssembly() == null)
                log4net.Config.XmlConfigurator.Configure(new FileInfo(System.Web.HttpContext.Current.Server.MapPath("~/Web.config")));
            else
                log4net.Config.XmlConfigurator.Configure(new FileInfo(Assembly.GetEntryAssembly().ManifestModule.Name + ".config"));
        }

        public void Audit(string strMessage, params object[] objs)
        {
            if (logger.IsWarnEnabled)
            {
                if (objs == null || objs.Length == 0)
                {
                    logger.Warn(AUDIT + strMessage);
                    return;
                }
                logger.Warn(AUDIT + string.Format(strMessage, objs));
            }
        }

        public void Debug(string strMessage, params object[] objs)
        {
            if (logger.IsDebugEnabled)
            {
                if (objs == null || objs.Length == 0)
                {
                    logger.Debug(DEBUG + strMessage);
                    return;
                }
                logger.Debug(DEBUG + string.Format(strMessage, objs));
            }
        }

        public void Exception(Exception error)
        {
            if (logger.IsErrorEnabled)
            {
                if (error != null)
                {
                    LogError(error, 0);
                }
            }
        }

        public void Exception(string strMessage, params object[] objs)
        {
            if (logger.IsErrorEnabled)
            {
                if (objs == null || objs.Length == 0)
                {
                    logger.Error(EXCPETION + strMessage);
                    return;
                }
                logger.Error(EXCPETION + string.Format(strMessage, objs));
            }
        }

        public void Info(string strMessage, params object[] objs)
        {
            logger.InfoFormat(strMessage, objs);
        }

        public void Performance(string strMessage, params object[] objs)
        {
            if (logger.IsInfoEnabled)
            {
                if (objs == null || objs.Length == 0)
                {
                    logger.Info(PERFORMANCE + strMessage);
                    return;
                }
                logger.Info(PERFORMANCE + string.Format(strMessage, objs));
            }
        }

        public void Security(string strMessage, params object[] objs)
        {
            if (logger.IsInfoEnabled)
            {
                if (objs == null || objs.Length == 0)
                {
                    logger.Info(SECURITY + strMessage);
                    return;
                }
                logger.Info(SECURITY + string.Format(strMessage, objs));
            }
        }

        #region Private Methods

        private void LogError(Exception ex, int innerLoop)
        {
            if (ex != null)
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine();
                builder.AppendLine(string.Concat("Inner exception number - ", innerLoop));
                builder.AppendLine("<<<<<<<<<<<<<<<<<<<---------start of Exception---------->>>>>>>>>>>>>>>>>>>>>");
                builder.AppendLine(ex.GetType().FullName);
                builder.AppendLine(ex.Message);
                builder.AppendLine(ex.StackTrace);
                builder.AppendLine();

                innerLoop++;
                if (ex.InnerException != null)
                {
                    logger.Error(builder.ToString());
                    LogError(ex.InnerException, innerLoop);
                }
                else
                {
                    builder.AppendLine("Main exception & its inner exception Log end");
                    builder.AppendLine("<<<<<<<<<<<<<<<<<<<----------------end ---------------->>>>>>>>>>>>>>>>>>>>>");
                    logger.Error(builder.ToString());
                }
            }
        }

        #endregion
    }
}
