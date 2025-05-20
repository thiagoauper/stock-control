using log4net;
using log4net.Config;
using StockControl.Logging.Interfaces.Loggers;

namespace StockControl.Logging.log4net.Loggers
{
    public class StockControlLogger : IStockControlLogger
    {
        private readonly ILog _log;

        public StockControlLogger()
        {
            _log = LogManager.GetLogger(typeof(StockControlLogger));
            BasicConfigurator.Configure();
        }

        public void LogDebug(string message)
        {
            _log.Debug(message);
        }

        public void LogError(string message, Exception exception)
        {
            _log.Error(message, exception);
        }

        public void LogInformation(string message)
        {
            _log.Info(message);
        }

        public void LogWarning(string message)
        {
            _log.Warn(message);
        }
    }
}
