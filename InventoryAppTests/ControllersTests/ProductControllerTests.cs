using InventoryApp.BusinessLogic.Interfaces;
using InventoryApp.Controllers;
using InventoryApp.Entities;
using InventoryApp.Enums;
using InventoryAppTests.Utilities;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace InventoryAppTests.ControllersTests
{
    [TestFixture]
    public class Tests
    {
        private ProductController productController;
        private readonly Mock<ILogger<ProductController>> loggerMock = new();
        private readonly Mock<ISubjectBL<Product>> productBLMock = new ();

        [SetUp]
        public void Setup()
        {
            productController = new ProductController(loggerMock.Object, productBLMock.Object);

            productBLMock.Setup(s => s.GetItems(It.IsAny<SortParameter>()))
                .Returns(ProductDataGenerator.ProductList);  
        }

        [Test]
        public void Should_Return_Not_Null_Collection_Successfully()
        {
            var productListResult = productController.Get(InventoryApp.Enums.SortParameter.NAME);
            Assert.IsNotNull(productListResult);
        }

        [Test]
        public void Should_Return_Valid_Collection_Successfully()
        {
            var productListResult = productController.Get(InventoryApp.Enums.SortParameter.NAME);
            Assert.AreEqual(ProductDataGenerator.ProductList.ToArray()[0].Name, 
                productListResult.ToArray()[0].Name);
        }
    }
}
