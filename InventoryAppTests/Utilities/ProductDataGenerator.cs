using InventoryApp.Entities;
using System.Collections;
using System.Collections.Generic;

namespace InventoryAppTests.Utilities
{
    public static class ProductDataGenerator
    {
        public static Product Table
        {
            get { 
                return  new Product { Name = "table", Price = 29.99, Quantity = 4 };
            }
        }
        public static Product Chair
        {
            get
            {
                return new Product { Name = "chair", Price = 9.99, Quantity = 7 };
            }
        }
        public static Product Couch
        {
            get
            {
                return new Product { Name = "couch", Price = 50, Quantity = 2 };
            }
        }
        public static Product Pillow
        {
            get
            {
                return new Product { Name = "pillow", Price = 5, Quantity = 1 };
            }
        }
        public static Product Bed
        {
            get
            {
                return new Product { Name = "bed", Price = 255.00, Quantity = 1 };
            }
        }
        public static Product Bench
        {
            get
            {
                return new Product { Name = "bench", Price = 29.99, Quantity = 3 };
            }
        }
        public static Product Stool
        {
            get
            {
                return new Product { Name = "stool", Price = 19.99, Quantity = 5 };
            }
        }


        public static List<Product> ProductList
        {
            get
            {
                return new List<Product>
                {
                    new Product() {
                        Name = "table",  Price = 2.99,Quantity = 3
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
