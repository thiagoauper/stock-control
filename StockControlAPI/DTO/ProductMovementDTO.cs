using StockControlAPI.Entities;
using StockControlAPI.Enums;

namespace StockControlAPI.DTO
{
    public class ProductMovementDTO
    {
        public Guid ProductCode { get; set; }
        public ProductMovementType MovementType { get; set; }
        public int Quantity { get; set; }

        internal bool IsValid()
        {
            return ProductCode != Guid.Empty && Quantity > 0;
        }

        internal ProductMovement ToModel()
        {
            return new ProductMovement(new Product { Code = ProductCode }, Quantity, MovementType);
        }
    }
}