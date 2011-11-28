using log4net;

namespace Infrastructure.Services
{
    public class Log4NetLogger : Core.Services.ILogger
    {
        private readonly ILog _log = LogManager.GetLogger("Log");

        static Log4NetLogger()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public void Log(string message, params object[] args)
        {
            _log.Info(string.Format(message, args));
        }
    }
}