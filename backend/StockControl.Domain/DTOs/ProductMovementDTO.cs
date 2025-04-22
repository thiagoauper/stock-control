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
            //TODO: This method is no longer necessary, as the validation is done in the ProductMovement class. Remove it when possible.
            return ProductCode != Guid.Empty && Quantity > 0;
        }

        public ProductMovement ToModel()
        {
            return new ProductMovement(
                new Product { Code = ProductCode },
                MovementType == ProductMovementType.In ? Quantity : null,
                MovementType == ProductMovementType.Out ? Quantity : null
            );
        }
    }
}