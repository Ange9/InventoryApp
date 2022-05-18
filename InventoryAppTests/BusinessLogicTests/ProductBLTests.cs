using InventoryApp.BusinessLogic;
using InventoryApp.BusinessLogic.Interfaces;
using InventoryApp.Controllers;
using InventoryApp.Entities;
using InventoryAppTests.Utilities;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
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

            Assert.AreEqual(ProductDataGenerator.SortedNameList[0], result.ToArray()[0].Name);
            Assert.AreEqual(ProductDataGenerator.SortedNameList[1], result.ToArray()[1].Name);
            Assert.AreEqual(ProductDataGenerator.SortedNameList[2], result.ToArray()[2].Name);
            Assert.AreEqual(ProductDataGenerator.SortedNameList[3], result.ToArray()[3].Name);
            Assert.AreEqual(ProductDataGenerator.SortedNameList[4], result.ToArray()[4].Name);

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
