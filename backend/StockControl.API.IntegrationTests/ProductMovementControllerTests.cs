using Microsoft.AspNetCore.Mvc;
using StockControl.API.Controllers;
using StockControl.Application.Core.Services;
using StockControl.Application.Interfaces.Services;
using StockControl.Business.Interfaces.Managers;
using StockControl.Business.Managers;
using StockControl.DataAccess.EntityFramework.Repositories;
using StockControl.DataAccess.Interfaces.Repositories;
using StockControl.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockControl.API.IntegrationTests
{
    public class ProductMovementControllerTests
    {
        private readonly IProductMovementService _productMovementService;
        private readonly IProductMovementManager _productMovementManager;
        private readonly IProductMovementRepository _productMovementRepository;
        
        private readonly IProductManager _productManager;
        private readonly IProductRepository _productRepository;
        
        private readonly IStockReportService _stockReportService;

        public ProductMovementControllerTests()
        {
            _productRepository = null; //TODO: MOCK THIS CLASS!!!
            _productMovementRepository = null; //TODO: MOCK THIS CLASS!!

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

        private ProductMovementDTO CreateValidProductMovement()
        {
            return new ProductMovementDTO
            {
                ProductCode = Guid.NewGuid().ToString(),
                Quantity = 1
            };
        }
    }
}
