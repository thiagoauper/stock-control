using StockControl.Domain.Entities;
using StockControl.Domain.Enums;

namespace StockControl.Domain.DTOs
{
    public class ProductMovementDTO
    {
        public Guid ProductCode { get; set; }
        public ProductMovementType MovementType { get; set; }
        public int Quantity { get; set; }

        public bool IsValid()
        {
            return ProductCode != Guid.Empty && Quantity > 0;
        }

        public ProductMovement ToModel()
        {
            return new ProductMovement(new Product { Code = ProductCode }, Quantity, MovementType);
        }
    }
}