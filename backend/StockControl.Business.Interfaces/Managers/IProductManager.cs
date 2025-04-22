using StockControl.Domain.Entities;

namespace StockControl.Business.Interfaces.Managers
{
    public interface IProductManager
    {
        IEnumerable<Product> GetAllProducts();
    }
}
