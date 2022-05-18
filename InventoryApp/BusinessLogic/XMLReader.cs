using InventoryApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace InventoryApp.BusinessLogic
{
    public class XMLReader
    {

        public List<Product> Products()
        {
           

            string filePath = "C:/Users/Rebeca/Downloads/Take Home Exercise (2) (1) (2)/inventory.xml";
            
            XmlReaderSettings settings = new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Parse,
                IgnoreWhitespace = true
            };
            var results = new List<Product>();
        
            using (XmlReader reader = XmlReader.Create(filePath, settings))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "product")
                        {                          
                            string id=reader.GetAttribute("name");
                            int quantity;
                            int.TryParse(reader.GetAttribute("quantity"), out quantity);
                            double price;
                            double.TryParse(reader.GetAttribute("price"), out price);

                            var product = new Product
                            {
                                Name = id,
                                Price = price,
                                Quatity = quantity,                             
                            };
                            results.Add(product);
                        }
                        
                    }
                }
            }
            return results;
        }
    }
}


