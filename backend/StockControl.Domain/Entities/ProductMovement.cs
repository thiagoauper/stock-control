namespace StockControl.Domain.Entities
{
    public class ProductMovement : EntityBase
    {
        public ProductMovement(Product product, int? totalInbound, int? totalOutbound)
        {
            Product = product;
            CreationDate = DateTime.UtcNow;
            TotalInbound = totalInbound;
            TotalOutbound = totalOutbound;
        }

        public ProductMovement(int productId, DateTime creationDate, int? totalInbound, int? totalOutbound)
        {
            ProductId = productId;
            CreationDate = creationDate;
            TotalInbound = totalInbound;
            TotalOutbound = totalOutbound;
        }

        public Product Product { get; set; }
        public int ProductId { get; set; }
        public DateTime CreationDate { get; set; }
        public int? TotalInbound {  get; set; }
        public int? TotalOutbound {  get; set; }

        public void Validate()
        {
            if (TotalInbound.HasValue && TotalOutbound.HasValue || (!TotalInbound.HasValue && !TotalOutbound.HasValue))
                throw new ArgumentException("Either Total Inbound field OR Total Outbound field should have a value.");

            if (TotalInbound.HasValue && TotalInbound.Value <= 0)
                throw new ArgumentException("Total Inbound field cannot be negative.", nameof(TotalInbound));

            if (TotalOutbound.HasValue && TotalOutbound.Value <= 0)
                throw new ArgumentException("Total Outbound field cannot be negative.", nameof(TotalOutbound));

            if (Product == null)
                throw new ArgumentException("Product cannot be null.", nameof(Product));

            if (Product.Code == Guid.Empty)
                throw new ArgumentException("Product code is required.", nameof(Product.Code));
        }
    }
}
