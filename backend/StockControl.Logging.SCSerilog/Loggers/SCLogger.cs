using StockControl.Logging.Interfaces.Loggers;

namespace StockControl.Logging.SCSerilog.Loggers
{
    public class SCLogger : IStockControlLogger
    {
        public void LogDebug(string message)
        {
            throw new NotImplementedException();
        }
        public void LogError(string message, Exception exception)
        {
            throw new NotImplementedException();
        }
        public void LogInformation(string message)
        {
            throw new NotImplementedException();
        }
        public void LogWarning(string message)
        {
            throw new NotImplementedException();
        }
    }
}
