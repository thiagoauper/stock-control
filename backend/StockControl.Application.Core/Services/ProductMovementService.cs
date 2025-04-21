using StockControl.Application.Interfaces.Services;
using StockControl.Business.Interfaces.Managers;
using StockControl.Domain.DTOs;

namespace StockControl.Application.Core.Services
{
    public class ProductMovementService : IProductMovementService
    {
        private readonly IProductMovementManager _productMovementManager;

        public ProductMovementService(IProductMovementManager productMovementManager)
        {
            this._productMovementManager = productMovementManager;
        }

        public int AddProductMovement(ProductMovementDTO productMovement)
        {
            return this._productMovementManager.AddProductMovement(productMovement.ToModel());
        }
    }
}
