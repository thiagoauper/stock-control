
using StockControl.Domain.Entities;

namespace StockControl.DataAccess.Interfaces.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        /// <summary>
        /// Retrieves a Product given its code.
        /// </summary>
        /// <returns>The Product with the specified code, or null if not found.</returns>
        Product GetProductByCode(string productCode);
    }
}
