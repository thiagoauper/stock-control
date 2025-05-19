using Microsoft.AspNetCore.Mvc;
using StockControl.Application.Interfaces.Services;
using StockControl.Domain.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductMovementController : StockControlControllerBase
    {
        private readonly IProductMovementService _productMovementService;

        public ProductMovementController(IProductMovementService productMovementService, Logging.Interfaces.Loggers.ILogger logger) : base (logger)
        {
            this._productMovementService = productMovementService;
        }

        // POST api/<ProductMovementController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductMovementDTO movement)
        {
            return EncapsulateAction(() =>
            {
                int productMovementId = this._productMovementService.AddProductMovement(movement.ToModel());
                _logger.LogInformation($"Product movement with ID {productMovementId} added successfully.");
                return productMovementId;
            });
        }
    }
}