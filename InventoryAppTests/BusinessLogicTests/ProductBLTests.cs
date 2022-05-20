using InventoryApp.BusinessLogic;
using InventoryApp.DataAccess.Interfaces;
using InventoryApp.Entities;
using InventoryAppTests.Utilities;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace InventoryAppTests.BusinessLogicTests
{
    [TestFixture]
    public class ProductBLTests
    {
        private ProductBL productBL;
        private readonly Mock<IXMLReader<Product>> xmlReader = new();
        private Mock<ILogger<ProductBL>> logger = new();


        [SetUp]
        public void Setup()
        {
            productBL = new ProductBL(xmlReader.Object, logger.Object);
            xmlReader.Setup(s => s.ReadXML(It.IsAny<string>()))
                .Returns(ProductDataGenerator.ProductList);

        }

        [Test]
        public void Should_Call_Reader_Successfully()
        {
            var result = productBL.GetItems("1");

            Assert.AreEqual("Bill", result.ToArray()[0].Name);
            xmlReader.Verify(x =>
                x.ReadXML(It.IsAny<string>()), Times.Once);

        }
    }
}
