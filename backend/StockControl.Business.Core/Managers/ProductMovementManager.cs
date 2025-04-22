using StockControl.Business.Interfaces.Managers;
using StockControl.DataAccess.Interfaces.Repositories;
using StockControl.Domain.Entities;

namespace StockControl.Business.Managers
{
    public class ProductMovementManager : IProductMovementManager
    {
        private readonly IProductMovementRepository _productMovementRepository;

        public ProductMovementManager(IProductMovementRepository productMovementRepository)
        {
            this._productMovementRepository = productMovementRepository;
        }

        public int AddProductMovement(ProductMovement productMovement)
        {
            if (productMovement == null)
                throw new ArgumentNullException(nameof(productMovement));

            productMovement.Validate();

            Console.WriteLine($"Product Movement Added: Product={productMovement.Product.Name}, " +
                              $"MovementType={productMovement.MovementType}, " +
                              $"Quantity={productMovement.Quantity}, " +
                              $"Date={productMovement.CreationDate}");

            int productMovementId = this._productMovementRepository.AddProductMovement(productMovement);

            return productMovementId;
        }

        public IEnumerable<ProductMovement> GetAllProductMovements()
        {
            return this._productMovementRepository.GetAllProductMovements();
        }
    }
}
