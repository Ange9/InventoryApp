using InventoryApp.DataAccess;
using InventoryApp.DataAccess.Interfaces;
using InventoryApp.Entities;
using InventoryAppTests.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Linq;


namespace InventoryAppTests.DataAccessTests
{
    [TestFixture]
    public class ProductXMLReaderTests
    {
        private ProductXMLReader xmlReader;
        private readonly Mock<IObjectComparator<Product>> comparator = new();
        private readonly Mock<IConfiguration> _configuration = new();
        private Mock<IConfigurationSection> mockConfSection = new();
        private Mock<ILogger<ProductXMLReader>> _logger = new();

        [SetUp]
        public void Setup()
        {
            xmlReader = new ProductXMLReader(_configuration.Object,_logger.Object);

            comparator.Setup(s => s.Compare(It.IsAny<Product>(), It.IsAny<Product>()))
                .Returns(1);

            //string path = Directory.GetCurrentDirectory();
            //string escapedPath = path.Replace(@"\", @"/");

            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"\inventory.xml");
            //string[] files = File.ReadAllLines(path);

            string path = "C:/Users/Rebeca/Downloads/Take Home Exercise (2) (1) (2)/inventory.xml";


            _configuration.SetupGet(x => x[It.Is<string>(s => s == "XMLReaderConfiguration:filepath")])
                .Returns(path);

            _configuration.SetupGet(x => x[It.Is<string>(s => s == "XMLReaderConfiguration:recordsToReturn")])
                .Returns("5");

        }


        [Test]
        public void Should_Create_Name_Comparator_Instance_When_Sorting_By_Name_Successfully()
        {
            IObjectComparator<Product> comparator = xmlReader.Create("0");
            Assert.IsInstanceOf(typeof(NameComparator), comparator);
        }
        [Test]
        public void Should_Create_Price_Comparator_Instance_When_Sorting_By_Price_Successfully()
        {
            IObjectComparator<Product> comparator = xmlReader.Create("1");
            Assert.IsInstanceOf(typeof(PriceComparator), comparator);
        }
        [Test]
        public void Should_Create_Quantity_Comparator_Instance_When_Sorting_By_Quantity_Successfully()
        {
            IObjectComparator<Product> comparator = xmlReader.Create("2");
            Assert.IsInstanceOf(typeof(QuantityComparator), comparator);
        }
        [Test]
        public void Should_Create_Name_Comparator_Instance_When_No_Valid_Sorting_Specified()
        {
            IObjectComparator<Product> comparator = xmlReader.Create("5");
            Assert.IsInstanceOf(typeof(NameComparator), comparator);
        }

        [Test]
        public void Should_Initially_Sort_Alphabetically_By_Name_Successfully()
        {
            NameSortSetup();
            var result =xmlReader.ReadXML("0");
            Assert.AreEqual("bed", result.ToArray()[0].Name);
            Assert.AreEqual("bench", result.ToArray()[1].Name);
            Assert.AreEqual("chair", result.ToArray()[2].Name);
            Assert.AreEqual("couch", result.ToArray()[3].Name);
            Assert.AreEqual("pillow", result.ToArray()[4].Name);
        }

        private void NameSortSetup()
        {
            #region setupComp
            comparator.Setup(s => s.Compare(ProductDataGenerator.Table, ProductDataGenerator.Bed))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Table, ProductDataGenerator.Bench))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Table, ProductDataGenerator.Chair))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Table, ProductDataGenerator.Couch))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Table, ProductDataGenerator.Pillow))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Table, ProductDataGenerator.Stool))
               .Returns(1);

            comparator.Setup(s => s.Compare(ProductDataGenerator.Bed, ProductDataGenerator.Table))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bed, ProductDataGenerator.Bench))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bed, ProductDataGenerator.Chair))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bed, ProductDataGenerator.Couch))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bed, ProductDataGenerator.Pillow))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bed, ProductDataGenerator.Stool))
               .Returns(-1);

            comparator.Setup(s => s.Compare(ProductDataGenerator.Bench, ProductDataGenerator.Bed))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bench, ProductDataGenerator.Table))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bench, ProductDataGenerator.Chair))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bench, ProductDataGenerator.Couch))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bench, ProductDataGenerator.Pillow))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bench, ProductDataGenerator.Stool))
               .Returns(-1);

            comparator.Setup(s => s.Compare(ProductDataGenerator.Chair, ProductDataGenerator.Bed))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Chair, ProductDataGenerator.Bench))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Chair, ProductDataGenerator.Table))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Chair, ProductDataGenerator.Couch))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Chair, ProductDataGenerator.Pillow))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Chair, ProductDataGenerator.Stool))
               .Returns(-1);

            comparator.Setup(s => s.Compare(ProductDataGenerator.Couch, ProductDataGenerator.Bed))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Couch, ProductDataGenerator.Bench))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Couch, ProductDataGenerator.Chair))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Couch, ProductDataGenerator.Table))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Couch, ProductDataGenerator.Pillow))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Couch, ProductDataGenerator.Stool))
               .Returns(-1);

            comparator.Setup(s => s.Compare(ProductDataGenerator.Pillow, ProductDataGenerator.Bed))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Pillow, ProductDataGenerator.Bench))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Pillow, ProductDataGenerator.Chair))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Pillow, ProductDataGenerator.Couch))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Pillow, ProductDataGenerator.Table))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Pillow, ProductDataGenerator.Stool))
               .Returns(-1);

            comparator.Setup(s => s.Compare(ProductDataGenerator.Stool, ProductDataGenerator.Bed))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Stool, ProductDataGenerator.Bench))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Stool, ProductDataGenerator.Chair))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Stool, ProductDataGenerator.Couch))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Stool, ProductDataGenerator.Pillow))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Stool, ProductDataGenerator.Table))
               .Returns(-1);
            #endregion setupComp
        }


        [Test]
        public void Should_Sort_Ascending_By_Price_Successfully()
        {
            PriceSortSetup();
            var result = xmlReader.ReadXML("1");
            Assert.AreEqual(5, result.ToArray()[0].Price);
            Assert.AreEqual(9.99, result.ToArray()[1].Price);
            Assert.AreEqual(19.99, result.ToArray()[2].Price);
            Assert.AreEqual(29.99, result.ToArray()[3].Price);
            Assert.AreEqual(29.99, result.ToArray()[4].Price);
        }

        private void PriceSortSetup()
        {
            #region priceSetup
            comparator.Setup(s => s.Compare(ProductDataGenerator.Table, ProductDataGenerator.Bed))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Table, ProductDataGenerator.Bench))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Table, ProductDataGenerator.Chair))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Table, ProductDataGenerator.Couch))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Table, ProductDataGenerator.Pillow))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Table, ProductDataGenerator.Stool))
               .Returns(1);

            comparator.Setup(s => s.Compare(ProductDataGenerator.Bed, ProductDataGenerator.Table))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bed, ProductDataGenerator.Bench))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bed, ProductDataGenerator.Chair))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bed, ProductDataGenerator.Couch))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bed, ProductDataGenerator.Pillow))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bed, ProductDataGenerator.Stool))
               .Returns(1);

            comparator.Setup(s => s.Compare(ProductDataGenerator.Bench, ProductDataGenerator.Bed))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bench, ProductDataGenerator.Table))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bench, ProductDataGenerator.Chair))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bench, ProductDataGenerator.Couch))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bench, ProductDataGenerator.Pillow))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bench, ProductDataGenerator.Stool))
               .Returns(1);

            comparator.Setup(s => s.Compare(ProductDataGenerator.Chair, ProductDataGenerator.Bed))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Chair, ProductDataGenerator.Bench))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Chair, ProductDataGenerator.Table))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Chair, ProductDataGenerator.Couch))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Chair, ProductDataGenerator.Pillow))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Chair, ProductDataGenerator.Stool))
               .Returns(-1);

            comparator.Setup(s => s.Compare(ProductDataGenerator.Couch, ProductDataGenerator.Bed))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Couch, ProductDataGenerator.Bench))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Couch, ProductDataGenerator.Chair))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Couch, ProductDataGenerator.Table))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Couch, ProductDataGenerator.Pillow))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Couch, ProductDataGenerator.Stool))
               .Returns(1);

            comparator.Setup(s => s.Compare(ProductDataGenerator.Pillow, ProductDataGenerator.Bed))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Pillow, ProductDataGenerator.Bench))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Pillow, ProductDataGenerator.Chair))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Pillow, ProductDataGenerator.Couch))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Pillow, ProductDataGenerator.Table))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Pillow, ProductDataGenerator.Stool))
               .Returns(-1);

            comparator.Setup(s => s.Compare(ProductDataGenerator.Stool, ProductDataGenerator.Bed))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Stool, ProductDataGenerator.Bench))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Stool, ProductDataGenerator.Chair))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Stool, ProductDataGenerator.Couch))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Stool, ProductDataGenerator.Pillow))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Stool, ProductDataGenerator.Table))
               .Returns(-1);
            #endregion priceSetup
        }

        [Test]
        public void Should_Sort_Ascending_By_Quantity_Successfully()
        {
            QuantitySortSetup();
            var result = xmlReader.ReadXML("2");
            Assert.AreEqual(1, result.ToArray()[0].Quantity);
            Assert.AreEqual(1, result.ToArray()[1].Quantity);
            Assert.AreEqual(2, result.ToArray()[2].Quantity);
            Assert.AreEqual(3, result.ToArray()[3].Quantity);
            Assert.AreEqual(4, result.ToArray()[4].Quantity);
        }

        private void QuantitySortSetup()
        {
            #region quantitySetup
            comparator.Setup(s => s.Compare(ProductDataGenerator.Table, ProductDataGenerator.Bed))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Table, ProductDataGenerator.Bench))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Table, ProductDataGenerator.Chair))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Table, ProductDataGenerator.Couch))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Table, ProductDataGenerator.Pillow))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Table, ProductDataGenerator.Stool))
               .Returns(-1);

            comparator.Setup(s => s.Compare(ProductDataGenerator.Bed, ProductDataGenerator.Table))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bed, ProductDataGenerator.Bench))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bed, ProductDataGenerator.Chair))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bed, ProductDataGenerator.Couch))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bed, ProductDataGenerator.Pillow))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bed, ProductDataGenerator.Stool))
               .Returns(-1);

            comparator.Setup(s => s.Compare(ProductDataGenerator.Bench, ProductDataGenerator.Bed))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bench, ProductDataGenerator.Table))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bench, ProductDataGenerator.Chair))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bench, ProductDataGenerator.Couch))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bench, ProductDataGenerator.Pillow))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Bench, ProductDataGenerator.Stool))
               .Returns(-1);

            comparator.Setup(s => s.Compare(ProductDataGenerator.Chair, ProductDataGenerator.Bed))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Chair, ProductDataGenerator.Bench))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Chair, ProductDataGenerator.Table))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Chair, ProductDataGenerator.Couch))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Chair, ProductDataGenerator.Pillow))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Chair, ProductDataGenerator.Stool))
               .Returns(1);

            comparator.Setup(s => s.Compare(ProductDataGenerator.Couch, ProductDataGenerator.Bed))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Couch, ProductDataGenerator.Bench))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Couch, ProductDataGenerator.Chair))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Couch, ProductDataGenerator.Table))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Couch, ProductDataGenerator.Pillow))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Couch, ProductDataGenerator.Stool))
               .Returns(-1);

            comparator.Setup(s => s.Compare(ProductDataGenerator.Pillow, ProductDataGenerator.Bed))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Pillow, ProductDataGenerator.Bench))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Pillow, ProductDataGenerator.Chair))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Pillow, ProductDataGenerator.Couch))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Pillow, ProductDataGenerator.Table))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Pillow, ProductDataGenerator.Stool))
               .Returns(-1);

            comparator.Setup(s => s.Compare(ProductDataGenerator.Stool, ProductDataGenerator.Bed))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Stool, ProductDataGenerator.Bench))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Stool, ProductDataGenerator.Chair))
               .Returns(-1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Stool, ProductDataGenerator.Couch))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Stool, ProductDataGenerator.Pillow))
               .Returns(1);
            comparator.Setup(s => s.Compare(ProductDataGenerator.Stool, ProductDataGenerator.Table))
               .Returns(1);
            #endregion quantitySetup
        }

       

        [Test]
        public void Should_Return_Top_Five_Successfully()
        {
            QuantitySortSetup();
            var result = xmlReader.ReadXML("2");
            Assert.AreEqual(5, result.Count());
        }
        [Test]
        public void Should_Ignore_Product_Couch_With_Invalid_Quantity_Format_Successfully()
        {
            string path = "C:/Users/Rebeca/Downloads/Take Home Exercise (2) (1) (2)/inventory2.xml";
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "XMLReaderConfiguration:filepath")])
                .Returns(path);
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "XMLReaderConfiguration:recordsToReturn")])
                .Returns("5");

            NameSortSetup();
            var result = xmlReader.ReadXML("0");
            Assert.AreEqual("bed", result.ToArray()[0].Name);
            Assert.AreEqual("bench", result.ToArray()[1].Name);
            Assert.AreEqual("chair", result.ToArray()[2].Name);
            Assert.AreEqual("pillow", result.ToArray()[3].Name);
            Assert.AreEqual("stool", result.ToArray()[4].Name);
        }

        [Test]
        public void Should_Ignore_Product_Couch_With_Null_Quantity_Tag_Successfully()
        {
            string path = "C:/Users/Rebeca/Downloads/Take Home Exercise (2) (1) (2)/inventory3.xml";
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "XMLReaderConfiguration:filepath")])
                .Returns(path);
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "XMLReaderConfiguration:recordsToReturn")])
                .Returns("5");

            NameSortSetup();
            var result = xmlReader.ReadXML("0");
            Assert.AreEqual("bed", result.ToArray()[0].Name);
            Assert.AreEqual("bench", result.ToArray()[1].Name);
            Assert.AreEqual("chair", result.ToArray()[2].Name);
            Assert.AreEqual("pillow", result.ToArray()[3].Name);
            Assert.AreEqual("stool", result.ToArray()[4].Name);
        }

        [Test]
        public void Should_Ignore_Product_Couch_With_Invalid_Price_Format_Successfully()
        {
            string path = "C:/Users/Rebeca/Downloads/Take Home Exercise (2) (1) (2)/inventory4.xml";
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "XMLReaderConfiguration:filepath")])
                .Returns(path);
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "XMLReaderConfiguration:recordsToReturn")])
                .Returns("5");

            NameSortSetup();
            var result = xmlReader.ReadXML("0");
            Assert.AreEqual("bed", result.ToArray()[0].Name);
            Assert.AreEqual("bench", result.ToArray()[1].Name);
            Assert.AreEqual("chair", result.ToArray()[2].Name);
            Assert.AreEqual("pillow", result.ToArray()[3].Name);
            Assert.AreEqual("stool", result.ToArray()[4].Name);
        }

        [Test]
        public void Should_Return_Top_Items_When_Less_Than_Five_Received_Successfully()
        {
            string path = "C:/Users/Rebeca/Downloads/Take Home Exercise (2) (1) (2)/inventory5.xml";
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "XMLReaderConfiguration:filepath")])
                .Returns(path);
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "XMLReaderConfiguration:recordsToReturn")])
                .Returns("5");
            QuantitySortSetup();
            var result = xmlReader.ReadXML("2");
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void Should_Format_Price_Successfully()
        {

        }


    }
}
