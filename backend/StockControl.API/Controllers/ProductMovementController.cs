using Microsoft.AspNetCore.Mvc;
using StockControl.API.DTO;
using StockControl.API.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductMovementController : ControllerBase
    {
        // POST api/<ProductMovementController>
        [HttpPost]
        public void Post([FromBody] ProductMovementDTO movement)
        {
            if (!movement.IsValid())
            {
                throw new ArgumentException("Invalid product movement data.");
            }

            ProductMovement productMovement = movement.ToModel();

            //TODO: Persist product movement in the data base!!
        }
    }
}