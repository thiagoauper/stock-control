using StockControl.Domain.Enums;

namespace StockControl.Domain.Entities
{
    public class ProductMovement : EntityBase
    {
        public ProductMovement(Product product, ProductMovementType movementType, int quantity)
        {
            Product = product;
            MovementType = movementType;
            CreationDate = DateTime.UtcNow;
            Quantity = quantity;
        }

        public ProductMovement(int productId, DateTime creationDate, ProductMovementType movementType, int quantity)
        {
            ProductId = productId;
            MovementType = movementType;
            CreationDate = creationDate;
            Quantity = quantity;
        }

        public Product Product { get; set; }
        public int ProductId { get; set; }
        public ProductMovementType MovementType { get; set; }
        public DateTime CreationDate { get; set; }
        public int Quantity {  get; set; }

        public void Validate()
        {
            if (Quantity <= 0)
                throw new ArgumentException("Quantity should be positive.", nameof(Quantity));

            if (Product == null)
                throw new ArgumentException("Product cannot be null.", nameof(Product));

            if (Product.Code == Guid.Empty)
                throw new ArgumentException("Product code is required.", nameof(Product.Code));
        }
    }
}
