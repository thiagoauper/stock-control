using Microsoft.AspNetCore.Mvc;

namespace StockControl.API.Controllers
{
    public abstract class StockControlControllerBase : ControllerBase
    {
        protected readonly Logging.Interfaces.Loggers.ILogger _logger;

        public delegate T ActionToBeExecuted<T>();

        protected StockControlControllerBase(Logging.Interfaces.Loggers.ILogger logger)
        {
            this._logger = logger;
        }

        public IActionResult EncapsulateAction<T>(ActionToBeExecuted<T> action)
        {
            try
            {
                return Ok(action.Invoke());
            }
            catch (ArgumentNullException ex)
            {
                return Problem(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return Problem(ex.Message);
            }
            catch (ApplicationException ex)
            {
                return Problem(ex.Message);
            }
            catch (Exception ex)
            {
                this._logger.LogError("An error occurred while executing the action.", ex);
                return Problem("An error occurred while executing call to the API.");
            }
        } 
    }
}
