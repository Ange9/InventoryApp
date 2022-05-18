using InventoryApp.Entities;
using System.Collections;
using System.Collections.Generic;

namespace InventoryAppTests.Utilities
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
                        Name = "Bill",  Price = 2.99,Quantity = 3
                    }
                };
            }
        }

        public static ArrayList SortedNameList
        {
            get
            {
                return new ArrayList(5)
                {
                    "bed", "bench","chair", "couch", "pillow"
                };
            }
        }
        public static ArrayList PriceList
        {
            get
            {
                return new ArrayList(5)
                {
                    1.1, 2.2,3.3, 4.4,5.5
                };
            }
        }

        public static ArrayList QuantityList
        {
            get
            {
                return new ArrayList(5)
                {
                    1,2,3,4,5
                };
            }
        }



    }
}
