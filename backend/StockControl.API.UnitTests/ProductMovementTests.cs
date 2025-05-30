﻿using StockControl.Domain.DTOs;
using StockControl.Domain.Entities;

namespace StockControl.API.UnitTests
{
    public class ProductMovementTests
    {
        private ProductMovementDTO CreateValidProductMovement()
        {
            return new ProductMovementDTO
            {
                ProductCode = Guid.NewGuid().ToString(),
                Quantity = 1
            };
        }

        /// <summary>
        /// Tests that when a product movement is created with all required fields, its validation method returns true.
        /// </summary>
        [Fact(DisplayName = "Product Movement should be valid when all required fields are defined")]
        public void Given_ProductMovement_When_AllRequiredFieldsAreDefined_Then_ValidationMethodReturnsTrue()
        {
            ProductMovementDTO productMovement = CreateValidProductMovement();
            ProductMovement pm = productMovement.ToModel();

            pm.Validate(); //should not throw any exception
        }

        /// <summary>
        /// Tests that when a product movement is created without a product code, its validation method returns false.
        /// </summary>
        [Fact(DisplayName = "Product Movement should be invalid when product code is not defined")]
        public void Given_ProductMovement_When_ProductCodeIsUndefined_Then_ValidationMethodReturnsFalse()
        {
            ProductMovementDTO productMovement = CreateValidProductMovement();
            productMovement.ProductCode = null;

            ProductMovement pm = productMovement.ToModel();
            Assert.Throws<ArgumentException>(() => pm.Validate());
        }

        /// <summary>
        /// Tests that when a product movement is created without a product quantity, its validation method returns false.
        /// </summary>
        [Fact(DisplayName = "Product Movement should be invalid when product quantity is not defined")]
        public void Given_ProductMovement_When_ProductQuantityIsUndefined_Then_ValidationMethodReturnsFalse()
        {
            ProductMovementDTO productMovement = CreateValidProductMovement();
            productMovement.Quantity = 0;

            ProductMovement pm = productMovement.ToModel();
            Assert.Throws<ArgumentException>(() => pm.Validate());
        }

        /// <summary>
        /// Tests that when a product movement is created with a negative product quantity, its validation method returns false.
        /// </summary>
        [Fact(DisplayName = "Product Movement should be invalid when product quantity is negative")]
        public void Given_ProductMovement_When_ProductQuantityIsNegative_Then_ValidationMethodReturnsFalse()
        {
            ProductMovementDTO productMovement = CreateValidProductMovement();
            productMovement.Quantity = -1 * new Random().Next();

            ProductMovement pm = productMovement.ToModel();
            Assert.Throws<ArgumentException>(() => pm.Validate());
        }

        /// <summary>
        /// Tests that when a product movement DTO is converted to a Model, their properties' values should be equivalent.
        /// </summary>
        [Fact(DisplayName = "Product Movement DTO and Model should have equivalent properties' values")]
        public void Given_ProductMovementDTO_When_ConvertedToProductMovementModel_Then_PropertiesValuesShouldBeEqual()
        {
            ProductMovementDTO productMovementDTO = CreateValidProductMovement();
            ProductMovement productMovementModel = productMovementDTO.ToModel();

            Assert.NotNull(productMovementModel);
            Assert.Equal(productMovementDTO.MovementType, (int)productMovementModel.MovementType);
            Assert.Equal(productMovementDTO.Quantity, productMovementModel.Quantity);
            
            Assert.NotNull(productMovementModel.Product);
            Assert.Equal(productMovementDTO.ProductCode, productMovementModel.Product.Code);
        }
    }
}