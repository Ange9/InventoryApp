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
            return xMLReader.GetProductsSortedList();
        }
        public void x() {
            List<Product> lp = new();
            lp.Add(new Product() {Name="A" });
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

    }
}