using InventoryApp.Entities;
using System.Collections.Generic;

namespace InventoryAppTests.ControllersTests.Utilities
{
    public static class ProductDataGenerator
    {
        public static IEnumerable<Product> ProductList
        {
            get
            {
                return new Product[1]
            {
                new Product() {
                    Name = "Bill",  Price = 2.99,Quatity = 3
                }
            };
            }
        }
    }
}
