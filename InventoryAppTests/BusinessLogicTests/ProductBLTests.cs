using InventoryApp.BusinessLogic;
using InventoryApp.BusinessLogic.Interfaces;
using InventoryApp.Controllers;
using InventoryApp.Entities;
using InventoryAppTests.Utilities;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections;
using System.Linq;

namespace InventoryAppTests.BusinessLogicTests
{
    [TestFixture]
    public class ProductBLTests
    {
   
        ProductBL productBL = new ProductBL();

        [SetUp]
        public void Setup()
        {
            

        }

        //when no sorting specified
        [Test]
        public void Should_Initially_Sort_Alphabetically_By_Name_Successfully()
        {
            var result=productBL.GetItems(1);

            Assert.AreEqual(ProductDataGenerator.NameList[0], result.ToArray()[0]);

        }

        //when sorting by name specified
        [Test]
        public void Should_Sort_Alphabetically_By_Name_Successfully()
        {

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
