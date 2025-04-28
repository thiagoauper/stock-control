using StockControl.Business.Interfaces.Managers;
using StockControl.DataAccess.Interfaces.Repositories;
using StockControl.Domain.Entities;

namespace StockControl.Business.Managers
{
    public class ProductMovementManager : IProductMovementManager
    {
        private readonly IProductMovementRepository _productMovementRepository;
        private readonly IProductRepository _productRepository;

        public ProductMovementManager(IProductMovementRepository productMovementRepository, IProductRepository productRepository)
        {
            this._productMovementRepository = productMovementRepository;
            this._productRepository = productRepository;
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

            Product selectedProduct = this._productRepository.GetProductByCode(productMovement.Product.Code);
            if (selectedProduct == null)
            {
                throw new ApplicationException($"There is no product with code '{productMovement.Product.Code}'.");
            }

            int productMovementId = this._productMovementRepository.AddProductMovement(productMovement);

            return productMovementId;
        }

        public IEnumerable<ProductMovement> GetAllProductMovements()
        {
            return this._productMovementRepository.GetAllProductMovements();
        }
    }
}
