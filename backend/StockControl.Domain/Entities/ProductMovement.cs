using StockControl.Domain.Enums;

namespace StockControl.Domain.Entities
{
    public class ProductMovement : EntityBase
    {
        public ProductMovement(Product product, int quantity, ProductMovementType type)
        {
            Product = product;
            CreationDate = DateTime.UtcNow;
            Quantity = quantity;
            Type = type;
        }

        public Product Product { get; set; }        
        public DateTime CreationDate { get; set; }
        public int Quantity {  get; set; }
        public ProductMovementType Type { get; set; }

        public void Validate()
        {
            if (Quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.", nameof(Quantity));

            if (Product == null)
                throw new ArgumentException("Product cannot be null.", nameof(Product));

            if (Product.Code == Guid.Empty)
                throw new ArgumentException("Product code is required.", nameof(Product.Code));
        }
    }
}
