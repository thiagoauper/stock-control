using StockControlAPI.DTO;

namespace StockControlAPI.UnitTests
{
    public class ProductMovementTests
    {
        private ProductMovementDTO CreateValidProductMovement()
        {
            return new ProductMovementDTO
            {
                ProductCode = Guid.NewGuid(),
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
            Assert.True(productMovement.IsValid());
        }

        /// <summary>
        /// Tests that when a product movement is created without a product code, its validation method returns false.
        /// </summary>
        [Fact(DisplayName = "Product Movement should be invalid when product code is not defined")]
        public void Given_ProductMovement_When_ProductCodeIsUndefined_Then_ValidationMethodReturnsFalse()
        {
            ProductMovementDTO productMovement = CreateValidProductMovement();
            productMovement.ProductCode = Guid.Empty;
            Assert.False(productMovement.IsValid());
        }

        /// <summary>
        /// Tests that when a product movement is created without a product quantity, its validation method returns false.
        /// </summary>
        [Fact(DisplayName = "Product Movement should be invalid when product quantity is not defined")]
        public void Given_ProductMovement_When_ProductQuantityIsUndefined_Then_ValidationMethodReturnsFalse()
        {
            ProductMovementDTO productMovement = CreateValidProductMovement();
            productMovement.Quantity = 0;
            Assert.False(productMovement.IsValid());
        }

        /// <summary>
        /// Tests that when a product movement is created with a negative product quantity, its validation method returns false.
        /// </summary>
        [Fact(DisplayName = "Product Movement should be invalid when product quantity is negative")]
        public void Given_ProductMovement_When_ProductQuantityIsNegative_Then_ValidationMethodReturnsFalse()
        {
            ProductMovementDTO productMovement = CreateValidProductMovement();
            productMovement.Quantity = -1;
            Assert.False(productMovement.IsValid());
        }
    }
}
