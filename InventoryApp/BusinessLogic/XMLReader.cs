using InventoryApp.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace InventoryApp.BusinessLogic
{
    public class XMLReader
    {

        public List<Product> GetProductsSortedList(int sortingParam=0)
        {
        
            switch (sortingParam)
            {
                case 0:
                    return ReadXMLSortingName();
                case 1:
                    break;
                case 2:
                    break;
            }
            return new List<Product>();

            
        }

        public List<Product> ReadXMLSortingName() {
            string filePath = "C:/Users/Rebeca/Downloads/Take Home Exercise (2) (1) (2)/inventory.xml";

            XmlReaderSettings settings = new()
            {
                DtdProcessing = DtdProcessing.Parse,
                IgnoreWhitespace = true
            };
            var productList = new List<Product>();
            using (XmlReader reader = XmlReader.Create(filePath, settings))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "product")
                        {
                            string id = reader.GetAttribute("name");
                            int quantity;
                            int.TryParse(reader.GetAttribute("quantity"), out quantity);
                            double price;
                            double.TryParse(reader.GetAttribute("price"), out price);

                            var product = new Product
                            {
                                Name = id,
                                Price = price,
                                Quantity = quantity,
                            };

                            int index = 0;

                            if (productList.Count == 0)
                            {
                                productList.Add(product);                             
                            }
                            else {
                                var inserted = false;
                                var greaterThanAll = false;
                                while (!inserted && !greaterThanAll) {
                                    if (index >= 5) {
                                        greaterThanAll = true;
                                    }
                                    if (productList.Count == index) {
                                        productList.Add(product);
                                        inserted = true;
                                    }
                                    var isNewSmaller = product.Name.CompareTo(productList[index].Name) < 0;
                                    if (isNewSmaller)
                                    {
                                        productList.Insert(index, product);
                                        inserted = true;
                                    }
                                    else {
                                        index++;                                        
                                    }
                                }
                                if (productList.Count>5) {
                                    productList.RemoveRange(5,1);
                                }
                            }                                                                         
                        }

                    }
                }
            }
            return productList;
        }
    }
}


