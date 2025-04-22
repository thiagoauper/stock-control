using Microsoft.Extensions.DependencyInjection;
using StockControl.DataAccess.Interfaces.Repositories;
using StockControl.Domain.Entities;

namespace StockControl.DataAccess.EntityFramework.Repositories
{
    public class ProductMovementRepository : IProductMovementRepository
    {
        private readonly StockControlDbContext _stockControlDbContext;

        //N.B. This constructor does not work due to the fact that it's not possible to inject a Scoped service into
        //     a Singleton service in .Net Core. Please have a read through the other constructor below.
        //public ProductMovementRepository(StockControlDbContext stockControlDbContext)
        //{
        //    _stockControlDbContext = stockControlDbContext;
        //}

        public ProductMovementRepository(IServiceScopeFactory serviceScopeFactory)
        {
            //This was necessary to make a Scoped service (StockControlDbContext) to work inside a Singleton service (ProductMovementRepository)
            //For more info, visit this url below (Using Scoped Services From Singletons in ASP.NET Core)
            //https://www.milanjovanovic.tech/blog/using-scoped-services-from-singletons-in-aspnetcore#the-solution---iservicescopefactory

            IServiceScope scope = serviceScopeFactory.CreateScope();
            _stockControlDbContext = scope.ServiceProvider.GetRequiredService<StockControlDbContext>();
        }

        /// <summary>
        /// Adds a new product movement to the repository.
        /// </summary>
        /// <param name="productMovement">The product movement to add.</param>
        public int AddProductMovement(ProductMovement productMovement)
        {
            if (productMovement == null)
                throw new ArgumentNullException(nameof(productMovement));

            Product selectedProduct = _stockControlDbContext.Product.SingleOrDefault(p => p.Code == productMovement.Product.Code);
            if(selectedProduct == null)
            {
                throw new ApplicationException($"There is no product with code '{productMovement.Product.Code}'.");
            }
            
            productMovement.Product = selectedProduct;
            productMovement.ProductId = selectedProduct.Id;
            
            _stockControlDbContext.ProductMovement.Add(productMovement);
            _stockControlDbContext.SaveChanges();

            return productMovement.Id;
        }

        /// <summary>
        /// Retrieves all product movements from the repository.
        /// </summary>
        /// <returns>A list of all product movements.</returns>
        public IEnumerable<ProductMovement> GetAllProductMovements()
        {
            return _stockControlDbContext.ProductMovement.ToList();
        }
    }
}
