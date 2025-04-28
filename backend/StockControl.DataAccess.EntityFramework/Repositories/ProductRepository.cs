using Microsoft.Extensions.DependencyInjection;
using StockControl.DataAccess.Interfaces.Repositories;
using StockControl.Domain.Entities;

namespace StockControl.DataAccess.EntityFramework.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StockControlDbContext _stockControlDbContext;

        //N.B. This constructor does not work due to the fact that it's not possible to inject a Scoped service into
        //     a Singleton service in .Net Core. Please have a read through the other constructor below.
        //public ProductRepository(StockControlDbContext stockControlDbContext)
        //{
        //    _stockControlDbContext = stockControlDbContext;
        //}

        public ProductRepository(IServiceScopeFactory serviceScopeFactory)
        {
            //This was necessary to make a Scoped service (StockControlDbContext) to work inside a Singleton service (ProductMovementRepository)
            //For more info, visit this url below (Using Scoped Services From Singletons in ASP.NET Core)
            //https://www.milanjovanovic.tech/blog/using-scoped-services-from-singletons-in-aspnetcore#the-solution---iservicescopefactory

            IServiceScope scope = serviceScopeFactory.CreateScope();
            _stockControlDbContext = scope.ServiceProvider.GetRequiredService<StockControlDbContext>();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _stockControlDbContext.Product.ToList();
        }

        public Product GetProductByCode(string productCode)
        {
            return _stockControlDbContext.Product.SingleOrDefault(p => p.Code == productCode);
        }
    }
}
