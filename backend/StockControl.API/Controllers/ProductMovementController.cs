using Microsoft.AspNetCore.Mvc;
using StockControl.Application.Interfaces;
using StockControl.Domain.DTOs;
using StockControl.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductMovementController : ControllerBase
    {
        private readonly IProductMovementService _productMovementService;

        public ProductMovementController(IProductMovementService productMovementService)
        {
            this._productMovementService = productMovementService;
        }

        // POST api/<ProductMovementController>
        [HttpPost]
        public void Post([FromBody] ProductMovementDTO movement)
        {
            this._productMovementService.AddProductMovement(movement);
        }
    }
}