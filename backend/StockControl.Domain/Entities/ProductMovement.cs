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
    }
}
