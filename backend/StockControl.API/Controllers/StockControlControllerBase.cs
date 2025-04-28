using Microsoft.AspNetCore.Mvc;

namespace StockControl.API.Controllers
{
    public abstract class StockControlControllerBase : ControllerBase
    {
        public delegate T ActionToBeExecuted<T>();

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
                //TODO: Enhancement to be done: Log the exception
                return Problem("An error occurred while adding the product movement.");
            }
        } 
    }
}
