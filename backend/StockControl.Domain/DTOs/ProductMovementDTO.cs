using StockControl.Domain.Entities;
using StockControl.Domain.Enums;

namespace StockControl.Domain.DTOs
{
    public class ProductMovementDTO
    {
        public string ProductCode { get; set; }
        public int MovementType { get; set; }
        public int Quantity { get; set; }

        public ProductMovement ToModel()
        {
            ProductMovementType movementType = Enum.Parse<ProductMovementType>(MovementType.ToString());

            return new ProductMovement(
                new Product { Code = ProductCode },
                movementType,
                Quantity
            );
        }
    }
}