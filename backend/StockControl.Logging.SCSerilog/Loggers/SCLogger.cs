using Serilog;
using Serilog.Core;
using StockControl.Logging.Interfaces.Loggers;

namespace StockControl.Logging.SCSerilog.Loggers
{
    public class SCLogger : IStockControlLogger, IDisposable
    {
        private readonly Logger _log;

        public SCLogger()
        {
            _log = new LoggerConfiguration()
                .WriteTo.File("log.txt") //TODO: This can be retrieved from a configuration file in the future.
                .CreateLogger();
        }
        public void LogDebug(string message)
        {
            _log.Debug(message);
        }
        public void LogError(string message, Exception exception)
        {
            _log.Error(exception, message);
        }
        public void LogInformation(string message)
        {
            _log.Information(message);
        }
        public void LogWarning(string message)
        {
            _log.Warning(message);
        }

        public void Dispose()
        {
            _log.Dispose();
        }
    }
}
