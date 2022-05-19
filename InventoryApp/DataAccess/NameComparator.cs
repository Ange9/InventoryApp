using InventoryApp.DataAccess.Interfaces;
using InventoryApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryApp.DataAccess
{
    public class NameComparator : IObjectComparator<Product>
    {
        
        public int Compare(Product source, Product destination)
        {
            return source.Name.CompareTo(destination.Name);
        }
    }
}
