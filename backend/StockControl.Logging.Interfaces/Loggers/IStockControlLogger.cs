namespace StockControl.Logging.Interfaces.Loggers
{
    public interface IStockControlLogger
    {
        void LogError(string message, Exception exception);
        void LogWarning(string message);
        void LogInformation(string message);
        void LogDebug(string message);
    }
}
