using Microsoft.AspNetCore.Mvc;
using Moq;
using StockControl.API.Controllers;
using StockControl.Application.Core.Services;
using StockControl.Application.Interfaces.Services;
using StockControl.Business.Interfaces.Managers;
using StockControl.Business.Managers;
using StockControl.DataAccess.Interfaces.Repositories;
using StockControl.Domain.DTOs;
using StockControl.Domain.Entities;

namespace StockControl.API.IntegrationTests
{
    public class ProductMovementControllerTests
    {
        private const string PRODUCT_CODE = "PROD001";

        private readonly IProductMovementService _productMovementService;
        private readonly IProductMovementManager _productMovementManager;
        private readonly IProductMovementRepository _productMovementRepository;
        
        private readonly IProductManager _productManager;
        private readonly IProductRepository _productRepository;
        
        private readonly IStockReportService _stockReportService;

        public ProductMovementControllerTests()
        {
            _productRepository = Mock.Of<IProductRepository>(pr => 
                pr.GetProductByCode(PRODUCT_CODE) == 
                    new Product 
                    {
                        Code = PRODUCT_CODE,
                        Id = 1,
                        Name = "Product 1"
                    }
                );

            _productMovementRepository = Mock.Of<IProductMovementRepository>();

            _productManager = new ProductManager(_productRepository);
            _productMovementManager = new ProductMovementManager(_productMovementRepository, _productRepository);

            _stockReportService = new StockReportService(_productMovementManager, _productManager);
            _productMovementService = new ProductMovementService(_productMovementManager, _stockReportService);
        }

        /// <summary>
        /// Tests that when a product movement is created without a product code, its Controller returns a Problem.
        /// </summary>
        [Fact(DisplayName = "Product Movement Controller should return a Problem when product code is not defined")]
        public void Given_ProductMovement_When_ProductCodeIsUndefined_Then_ProblemIsReturned()
        {
            ProductMovementDTO productMovement = CreateValidProductMovement();

            ProductMovementController productMovementController = new ProductMovementController(_productMovementService);

            productMovement.ProductCode = null;

            IActionResult actionResult = productMovementController.Post(productMovement);
            Assert.IsType<ObjectResult>(actionResult);
            ObjectResult problem = (ObjectResult)actionResult;
            ProblemDetails problemDetails = (ProblemDetails)problem.Value;
            Assert.Equal("Product code is required. (Parameter 'Code')", problemDetails.Detail);
        }

        /// <summary>
        /// Tests that when a product movement valid, its Controller returns a Ok when trying to add it.
        /// </summary>
        [Fact(DisplayName = "Product Movement Controller should return Ok when input data is valid")]
        public void Given_ProductMovementIsValid_When_TryingToAddIt_Then_ItShouldReturnOk()
        {
            ProductMovementDTO productMovement = CreateValidProductMovement();

            ProductMovementController productMovementController = new ProductMovementController(_productMovementService);

            IActionResult actionResult = productMovementController.Post(productMovement);
            Assert.IsType<OkObjectResult>(actionResult);
            OkObjectResult okResult = (OkObjectResult)actionResult;
            //Assert.Equal(1, okResult.Value); //TODO: Make this assertion work!!! Setup _productMovementRepository Mock properly!!
        }

        private ProductMovementDTO CreateValidProductMovement()
        {
            return new ProductMovementDTO
            {
                ProductCode = PRODUCT_CODE,
                Quantity = 1
            };
        }
    }
}
