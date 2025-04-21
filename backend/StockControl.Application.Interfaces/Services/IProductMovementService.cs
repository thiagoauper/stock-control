using StockControl.Domain.DTOs;

namespace StockControl.Application.Interfaces.Services
{
    public interface IProductMovementService
    {
        /// <summary>
        /// Adds a new product movement to the system.
        /// </summary>
        /// <param name="productMovement">The product movement to add.</param>
        void AddProductMovement(ProductMovementDTO productMovement);
    }
}
