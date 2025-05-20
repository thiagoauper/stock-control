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
using StockControl.Domain.Enums;
using StockControl.Logging.Interfaces.Loggers;

namespace StockControl.API.IntegrationTests
{
    public class ProductMovementControllerTests
    {
        private readonly Product PRODUCT_MOCK;
        private readonly ProductMovement PRODUCT_MOVEMENT_MOCK;

        private readonly IProductMovementService _productMovementService;
        private readonly IProductMovementManager _productMovementManager;
        private readonly IProductMovementRepository _productMovementRepository;
        
        private readonly IProductManager _productManager;
        private readonly IProductRepository _productRepository;
        
        private readonly IStockReportService _stockReportService;

        private readonly IStockControlLogger _logger;

        public ProductMovementControllerTests()
        {
            PRODUCT_MOCK = new Product
            {
                Code = "PROD001",
                Id = 123,
                Name = "Product 1"
            };

            PRODUCT_MOVEMENT_MOCK = new ProductMovement(PRODUCT_MOCK, ProductMovementType.Inbound, 10)
            {
                Id = 456,
                ProductId = PRODUCT_MOCK.Id,
            };  

            _productRepository = Mock.Of<IProductRepository>(pr =>
                pr.GetProductByCode(PRODUCT_MOCK.Code) == PRODUCT_MOCK
                && pr.GetAllProducts() == new List<Product>{ PRODUCT_MOCK }
                );

            var productMovementRepositoryMock = new Mock<IProductMovementRepository>();
            productMovementRepositoryMock.Setup(pmr => pmr.AddProductMovement(It.IsAny<ProductMovement>())).Returns(PRODUCT_MOCK.Id);
            productMovementRepositoryMock.Setup(pmr => pmr.GetAllProductMovements()).Returns(new List<ProductMovement> { PRODUCT_MOVEMENT_MOCK });
            _productMovementRepository = productMovementRepositoryMock.Object;

            _productManager = new ProductManager(_productRepository);
            _productMovementManager = new ProductMovementManager(_productMovementRepository, _productRepository);

            _stockReportService = new StockReportService(_productMovementManager, _productManager);
            _productMovementService = new ProductMovementService(_productMovementManager, _stockReportService);
            
            _logger = new Mock<IStockControlLogger>().Object;
        }

        /// <summary>
        /// Tests that when a product movement is created without a product code, its Controller returns a Problem.
        /// </summary>
        [Fact(DisplayName = "Product Movement Controller should return a Problem when product code is not defined")]
        public void Given_ProductMovement_When_ProductCodeIsUndefined_Then_ProblemIsReturned()
        {
            ProductMovementDTO productMovement = CreateValidProductMovement();

            ProductMovementController productMovementController = new ProductMovementController(_productMovementService, _logger);

            productMovement.ProductCode = null;

            IActionResult actionResult = productMovementController.Post(productMovement);
            Assert.IsType<ObjectResult>(actionResult);
            ObjectResult problem = (ObjectResult)actionResult;
            ProblemDetails problemDetails = (ProblemDetails)problem.Value;
            Assert.Equal("Product code is required. (Parameter 'Code')", problemDetails.Detail);
        }

        /// <summary>
        /// Tests that when a product movement is created without quantity, its Controller returns a Problem.
        /// </summary>
        [Fact(DisplayName = "Product Movement Controller should return a Problem when product quantity is not defined")]
        public void Given_ProductMovement_When_ProductQuantityIsUndefined_Then_ProblemIsReturned()
        {
            ProductMovementDTO productMovement = CreateValidProductMovement();

            ProductMovementController productMovementController = new ProductMovementController(_productMovementService, _logger);

            productMovement.Quantity = 0;

            IActionResult actionResult = productMovementController.Post(productMovement);
            Assert.IsType<ObjectResult>(actionResult);
            ObjectResult problem = (ObjectResult)actionResult;
            ProblemDetails problemDetails = (ProblemDetails)problem.Value;
            Assert.Equal("Quantity should be positive. (Parameter 'Quantity')", problemDetails.Detail);
        }

        /// <summary>
        /// Tests that when a product movement is of type outbound and its quantity is greater then the product's stock, its Controller returns a Problem.
        /// </summary>
        [Fact(DisplayName = "Product Movement Controller should return a Problem when product outbound quantity is greater than the available stock")]
        public void Given_ProductMovement_When_ProductOutboundQuantityIsGreaterThenAvailableStock_Then_ProblemIsReturned()
        {
            ProductMovementDTO productMovement = CreateValidProductMovement();

            ProductMovementController productMovementController = new ProductMovementController(_productMovementService, _logger);

            productMovement.MovementType = (int)ProductMovementType.Outbound;
            productMovement.Quantity = PRODUCT_MOVEMENT_MOCK.Quantity + 1;

            IActionResult actionResult = productMovementController.Post(productMovement);
            Assert.IsType<ObjectResult>(actionResult);
            ObjectResult problem = (ObjectResult)actionResult;
            ProblemDetails problemDetails = (ProblemDetails)problem.Value;
            Assert.Equal("It is not possible to make a Product Movement which leads to a negative balance.", problemDetails.Detail);
        }

        /// <summary>
        /// Tests that when a product movement valid, its Controller returns a Ok when trying to add it.
        /// </summary>
        [Fact(DisplayName = "Product Movement Controller should return Ok when input data is valid")]
        public void Given_ProductMovementIsValid_When_TryingToAddIt_Then_ItShouldReturnOk()
        {
            ProductMovementDTO productMovement = CreateValidProductMovement();

            ProductMovementController productMovementController = new ProductMovementController(_productMovementService, _logger);

            IActionResult actionResult = productMovementController.Post(productMovement);
            Assert.IsType<OkObjectResult>(actionResult);
            OkObjectResult okResult = (OkObjectResult)actionResult;
            Assert.Equal(PRODUCT_MOCK.Id, okResult.Value);
        }

        private ProductMovementDTO CreateValidProductMovement()
        {
            return new ProductMovementDTO
            {
                ProductCode = PRODUCT_MOCK.Code,
                Quantity = 1
            };
        }
    }
}
