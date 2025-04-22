using StockControl.Business.Interfaces.Managers;
using StockControl.DataAccess.Interfaces.Repositories;
using StockControl.Domain.Entities;

namespace StockControl.Business.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return this._productRepository.GetAllProducts();
        }
    }
}
