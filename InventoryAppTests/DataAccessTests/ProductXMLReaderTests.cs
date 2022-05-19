using InventoryApp.DataAccess;
using InventoryApp.DataAccess.Interfaces;
using InventoryApp.Entities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InventoryAppTests.DataAccessTests
{
    [TestFixture]
    public class ProductXMLReaderTests
    {
        private ProductXMLReader xmlReader;
        private readonly Mock<IObjectComparator<Product>> comparator = new();

        [SetUp]
        public void Setup()
        {
            xmlReader = new ProductXMLReader();

            comparator.Setup(s => s.Compare(It.IsAny<Product>(), It.IsAny<Product>()))
                .Returns(1);

        }

        //when no sorting specified
        [Test]
        public void Should_Initially_Sort_Alphabetically_By_Name_Successfully()
        {
            //var result = productBL.GetItems(1);

            //Assert.AreEqual("Bill", result.ToArray()[0].Name);

        }

        //when sorting by name specified
        [Test]
        public void Should_Sort_Alphabetically_By_Name_Successfully()
        {

            List<Product> lp = new();
            lp.Add(new Product() { Name = "A" });
            lp.Add(new Product() { Name = "B" });
            lp.Add(new Product() { Name = "D" });
            lp.Insert(2, new Product() { Name = "C" });
            //ArrayList myList = new ArrayList(5);
            //myList.Add("A");
            //myList.Add("B");
            //myList.Add("C");
            //myList.Add("D");
            //myList.Add("E");
            //myList.Insert(1, "Z");
            //myList.RemoveAt(5);

            foreach (Product item in lp)
            {
                var c = item.Name;
            }

        }

        //when sorting by price specified
        [Test]
        public void Should_Sort_Ascending_By_Price_Successfully()
        {

        }


        //when sorting by quantity specified
        [Test]
        public void Should_Sort_Ascending_By_Quantity_Successfully()
        {

        }

        [Test]
        public void Should_Return_Top_Five_Successfully()
        {

        }

        [Test]
        public void Should_Return_Top_Items_When_Less_Than_Five_Received_Successfully()
        {

        }

        [Test]
        public void Should_Format_Price_Successfully()
        {

        }


    }
}
