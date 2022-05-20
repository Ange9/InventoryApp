using InventoryApp.BusinessLogic;
using InventoryApp.DataAccess.Interfaces;
using InventoryApp.Entities;
using InventoryApp.Enums;
using InventoryAppTests.Utilities;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace InventoryAppTests.BusinessLogicTests
{
    [TestFixture]
    public class ProductBLTests
    {
        private ProductBL productBL;
        private readonly Mock<IXMLReader<Product>> xmlReader = new();
        private readonly Mock<ILogger<ProductBL>> logger = new();

        [SetUp]
        public void Setup()
        {
            productBL = new ProductBL(xmlReader.Object, logger.Object);
            xmlReader.Setup(s => s.ReadXML(It.IsAny<SortParameter>()))
                .Returns(ProductDataGenerator.ProductList);
        }

        [Test]
        public void Should_Call_Reader_Successfully()
        {
            var result = productBL.GetItems(SortParameter.PRICE);

            Assert.AreEqual("table", result.ToArray()[0].Name);
            xmlReader.Verify(x =>
                x.ReadXML(It.IsAny<SortParameter>()), Times.Once);
        }
    }
}
