using Microsoft.AspNetCore.Mvc;
using StockControl.Logging.Interfaces.Loggers;
using System.Diagnostics;

namespace StockControl.API.Controllers
{
    public abstract class StockControlControllerBase : ControllerBase
    {
        protected readonly IStockControlLogger _logger;

        public delegate T ActionToBeExecuted<T>();

        protected StockControlControllerBase(IStockControlLogger logger)
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
                this._logger.LogWarning(ex.Message);
                return Problem(ex.Message);
            }
            catch (ArgumentException ex)
            {
                this._logger.LogWarning(ex.Message);
                return Problem(ex.Message);
            }
            catch (ApplicationException ex)
            {

                this._logger.LogWarning(ex.Message);
                return Problem(ex.Message);
            }
            catch (Exception ex)
            {
                this._logger.LogError("An error occurred while executing the action.", ex);
                string errorMessage = "An error occurred while executing call to the API.";

                if (Debugger.IsAttached)
                {
                    errorMessage = ex.Message; //passing actual error message to the client when in Development time
                }

                return Problem(errorMessage);
            }
        } 
    }
}