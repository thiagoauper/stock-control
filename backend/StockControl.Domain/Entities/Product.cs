namespace StockControl.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public Guid Code { get; set; }
    }
}
