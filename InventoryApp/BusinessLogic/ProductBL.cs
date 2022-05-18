using InventoryApp.BusinessLogic.Interfaces;
using InventoryApp.Entities;
using System;
using System.Collections.Generic;

namespace InventoryApp.BusinessLogic
{
    public class ProductBL : IItemBL<Product>
    {
        public IEnumerable<Product> GetItems(int sorting)
        {
            throw new NotImplementedException();
        }

    }
}