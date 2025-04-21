using StockControl.Domain.Entities;

namespace StockControl.DataAccess.Interfaces.Repositories
{
    public interface IProductMovementRepository
    {
        /// <summary>
        /// Adds a new product movement to the repository.
        /// </summary>
        /// <param name="productMovement">The product movement to add.</param>
        int AddProductMovement(ProductMovement productMovement);
        /// <summary>
        /// Retrieves all product movements from the repository.
        /// </summary>
        /// <returns>A list of all product movements.</returns>
        IEnumerable<ProductMovement> GetAllProductMovements();
        /// <summary>
        /// Retrieves a specific product movement by its ID.
        /// </summary>
        /// <param name="id">The ID of the product movement to retrieve.</param>
        /// <returns>The product movement with the specified ID, or null if not found.</returns>
    }
}
