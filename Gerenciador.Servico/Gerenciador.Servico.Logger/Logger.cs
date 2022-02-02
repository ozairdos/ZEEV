using log4net;
using System;
using System.Reflection;

namespace Gerenciador.Servico.Logger
{
    public class Logger
    {
        private static ILog logBLL = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Configure()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static void Error(string Message, Exception ex = null)
        {
            logBLL.Error(Message, ex);
        }

        public static void Fatal(Exception ex, string Message = "")
        {
            logBLL.Fatal(Message, ex);
        }

        public static void Warn(string Message, Exception ex = null)
        {
            logBLL.Warn(Message, ex);
        }

        public static void Info(string Message)
        {
            logBLL.Info(Message);
        }
    }
}
