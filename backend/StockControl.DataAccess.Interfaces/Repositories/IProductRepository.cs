
using StockControl.Domain.Entities;

namespace StockControl.DataAccess.Interfaces.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
    }
}
