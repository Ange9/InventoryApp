using InventoryApp.BusinessLogic.Interfaces;
using InventoryApp.Entities;
using System;
using System.Collections.Generic;

namespace InventoryApp.BusinessLogic
{
    public class ProductBL : IItemBL<Product>
    {
        XMLReader xMLReader = new XMLReader();
        public IEnumerable<Product> GetItems(int sorting)
        {
            return xMLReader.Products();
        }
        public void x() {
            //ArrayList myList = new ArrayList(5);
            //myList.Add("A");
            //myList.Add("B");
            //myList.Add("C");
            //myList.Add("D");
            //myList.Add("E");
            //myList.Insert(1, "Z");
            //myList.RemoveAt(5);

            //foreach (string str in myList)
            //{
            //    var c = str;
            //}
        }

    }
}