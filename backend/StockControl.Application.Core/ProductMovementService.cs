using StockControl.Application.Interfaces;
using StockControl.Domain.DTOs;
using StockControl.Domain.Entities;

namespace StockControl.Application.Core
{
    public class ProductMovementService : IProductMovementService
    {
        public void AddProductMovement(ProductMovementDTO productMovement)
        {
            if (!productMovement.IsValid())
            {
                throw new ArgumentException("Invalid product movement data.");
            }

            ProductMovement movement = productMovement.ToModel();

            //TODO: Persist product movement in the data base!!!
        }
    }
}
