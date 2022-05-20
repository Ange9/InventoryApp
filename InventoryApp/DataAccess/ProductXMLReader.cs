using InventoryApp.DataAccess.Interfaces;
using InventoryApp.Entities;
using InventoryApp.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Xml;

namespace InventoryApp.DataAccess
{
    public class ProductXMLReader: IXMLReader<Product>
    {
        private IObjectComparator<Product> _comparator;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ProductXMLReader> _logger;

        public ProductXMLReader(IConfiguration configuration, ILogger<ProductXMLReader> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public IObjectComparator<Product> CreateComparator(SortParameter sorting)
        {
            return sorting switch
            {
                SortParameter.NAME => new NameComparator(),
                SortParameter.PRICE => new PriceComparator(),
                SortParameter.QUANTITY => new QuantityComparator(),
                _ => new NameComparator(),
            };
        }

        public List<Product> ReadXML(SortParameter sorting)
        {
            _comparator = CreateComparator(sorting);
            var productList = new List<Product>();

            int numberOfRecordsToReturn = GetMaxRecordsToReturn();

            using (XmlReader reader = XmlReader.Create(GetFilePath(), GetSettings()))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "product")
                        {
                            string name = reader.GetAttribute("name");
                            var quantityElement = reader.GetAttribute("qty");
                            var priceElement = reader.GetAttribute("price");

                            var allAttributeHasTag = ValidateIfAllAttributeHasTag(name, quantityElement, priceElement);

                            //parse numeric values
                            var parsedToInt = int.TryParse(quantityElement, out int quantity);
                            var parsedToDouble = double.TryParse(priceElement, out double price);

                            //validate formats of each value
                            bool allAttributesHasValidFormat = ValidateIfAllAttributeHasValidFormat(parsedToInt, quantity, parsedToDouble, price);
                            if (!allAttributeHasTag || !allAttributesHasValidFormat)
                            {
                                continue;//skip node
                            }

                            var product = new Product
                            {
                                Name = name,
                                Price = price,
                                Quantity = quantity,
                            };
                            //compare element with existing list, try to insert o discard value if is greater than existing sorted values
                            CompareToExistingElements(numberOfRecordsToReturn, product, ref productList);
                        }
                    }
                }
            }
            return productList;
        }

        private int GetMaxRecordsToReturn()
        {
            return int.Parse(_configuration["XMLReaderConfiguration:recordsToReturn"]);
        }

        private string GetFilePath()
        {
            return _configuration["XMLReaderConfiguration:filepath"];
        }

        private XmlReaderSettings GetSettings()
        {
             XmlReaderSettings settings = new()
            {
                DtdProcessing = DtdProcessing.Parse,
                IgnoreWhitespace = true
            };
            return settings;
        }

        private bool ValidateIfAllAttributeHasValidFormat(bool parsedToInt, int quantity, bool parsedToDouble, double price)
        {     
            if (!parsedToInt)
            {
                _logger.LogWarning("Skiping invalid data type on quantity: " + quantity);
            }
            if (!parsedToDouble)
            {
                _logger.LogWarning("Skiping invalid data type on price: " + price);
            }
            return parsedToDouble && parsedToInt;
        }

        private bool ValidateIfAllAttributeHasTag(string nameElement, string quantityElement, string priceElement)
        {
            if (nameElement == null)
            {
                _logger.LogWarning("Skiping, no tag found for Name");
                return false;
            }
            if (quantityElement == null)
            {
                _logger.LogWarning("Skiping, no tag found for Quantity");
                return false;
            }
            if (priceElement == null)
            {
                _logger.LogWarning("Skiping, no tag found for Price");
                return false;
            }
            return true;
        }
        private int CompareToExistingElements(int numberOfRecordsToReturn,  Product product, ref List<Product> productList)
        {
            int index = 0;

            //empty list, add first value
            if (productList.Count == 0)
            {
                productList.Add(product);
            }
            else
            {
                var inserted = false;
                var greaterThanAll = false;
                while (!inserted && !greaterThanAll)
                {
                    //new value greater than all existing, ignore
                    if (index >= numberOfRecordsToReturn)
                    {
                        greaterThanAll = true;
                        continue;
                    }
                    //list is empty in index position
                    if (productList.Count == index)
                    {
                        productList.Add(product);
                        inserted = true;
                        continue;
                    }
                    var isNewSmaller = this._comparator.Compare(product, productList[index]) < 0;
                    //if new value is smaller than existing value in index position
                    if (isNewSmaller)
                    {
                        productList.Insert(index, product);
                        inserted = true;
                        continue;
                    }
                    //if new value is greater than evaluating position in index, continue iterating
                    else
                    {
                        index++;
                    }
                }
                //if shift cause by adding value in the middle of list results in list bigger than required, remove last value
                if (productList.Count > numberOfRecordsToReturn)
                {
                    productList.RemoveRange(numberOfRecordsToReturn, 1);
                }
            }

            return index;
        }   
    }
}


