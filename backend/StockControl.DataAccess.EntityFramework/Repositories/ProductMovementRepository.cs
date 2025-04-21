using StockControl.DataAccess.Interfaces.Repositories;
using StockControl.Domain.Entities;

namespace StockControl.DataAccess.EntityFramework.Repositories
{
    public class ProductMovementRepository : IProductMovementRepository
    {
        //TODO: REPLACE THIS TEMPORARY IN-MEMORY IMPLEMENTATION WITH ACTUAL ENTITY FRAMEWORK CODE!

        private readonly List<ProductMovement> _productMovements;

        public ProductMovementRepository()
        {
            _productMovements = new List<ProductMovement>();
        }

        /// <summary>
        /// Adds a new product movement to the repository.
        /// </summary>
        /// <param name="productMovement">The product movement to add.</param>
        public int AddProductMovement(ProductMovement productMovement)
        {
            if (productMovement == null)
                throw new ArgumentNullException(nameof(productMovement));

            productMovement.Id = _productMovements.Count > 0
                ? _productMovements.Max(pm => pm.Id) + 1
                : 1;

            _productMovements.Add(productMovement);
            return productMovement.Id;
        }

        /// <summary>
        /// Retrieves all product movements from the repository.
        /// </summary>
        /// <returns>A list of all product movements.</returns>
        public IEnumerable<ProductMovement> GetAllProductMovements()
        {
            return _productMovements;
        }
    }
}
