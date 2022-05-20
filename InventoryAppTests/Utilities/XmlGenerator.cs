using System.IO;
using System.Xml;

namespace InventoryAppTests.Utilities
{
    public static class XmlGenerator
    {

        public static string XmlStringInventory1
        {
            get
            {
                return CreateXml1();
            }
        }

        private static string CreateXml1()
        {
            XmlWriterSettings settings = GetWriterSettings();
            #region newWriter
            using (XmlWriter writer = XmlWriter.Create("inventory1.xml", settings))
            {
                writer.WriteStartDocument(); // <?xml version="1.0" encoding="utf-16"?>
                writer.WriteStartElement("inventory"); //<Inventory>

                writer.WriteStartElement("products");//<Products>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("table");
                writer.WriteStartAttribute("price");
                writer.WriteString("29.99");
                writer.WriteStartAttribute("qty");
                writer.WriteString("4");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("chair");
                writer.WriteStartAttribute("price");
                writer.WriteString("9.99");
                writer.WriteStartAttribute("qty");
                writer.WriteString("7");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("couch");
                writer.WriteStartAttribute("price");
                writer.WriteString("50");
                writer.WriteStartAttribute("qty");
                writer.WriteString("2");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("pillow");
                writer.WriteStartAttribute("price");
                writer.WriteString("5");
                writer.WriteStartAttribute("qty");
                writer.WriteString("1");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("bed");
                writer.WriteStartAttribute("price");
                writer.WriteString("255.00");
                writer.WriteStartAttribute("qty");
                writer.WriteString("1");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("bench");
                writer.WriteStartAttribute("price");
                writer.WriteString("29.99");
                writer.WriteStartAttribute("qty");
                writer.WriteString("3");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("stool");
                writer.WriteStartAttribute("price");
                writer.WriteString("19.99");
                writer.WriteStartAttribute("qty");
                writer.WriteString("5");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Flush();
                #endregion newWriter

            }
            return "inventory1.xml";
        }

        public static string XmlWithDuplicatedProductName
        {
            get
            {
                return CreateXmlWithDuplicatedProductName();
            }
        }

        private static string CreateXmlWithDuplicatedProductName()
        {
            XmlWriterSettings settings = GetWriterSettings();
            #region newWriter
            using (XmlWriter writer = XmlWriter.Create("xmlWithDuplicatedProductName.xml", settings))
            {
                writer.WriteStartDocument(); // <?xml version="1.0" encoding="utf-16"?>
                writer.WriteStartElement("inventory"); //<Inventory>

                writer.WriteStartElement("products");//<Products>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("table");
                writer.WriteStartAttribute("price");
                writer.WriteString("29.99");
                writer.WriteStartAttribute("qty");
                writer.WriteString("4");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("chair");
                writer.WriteStartAttribute("price");
                writer.WriteString("9.99");
                writer.WriteStartAttribute("qty");
                writer.WriteString("7");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("couch");
                writer.WriteStartAttribute("price");
                writer.WriteString("50");
                writer.WriteStartAttribute("qty");
                writer.WriteString("2");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("pillow");
                writer.WriteStartAttribute("price");
                writer.WriteString("5");
                writer.WriteStartAttribute("qty");
                writer.WriteString("1");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("bed");
                writer.WriteStartAttribute("price");
                writer.WriteString("255.00");
                writer.WriteStartAttribute("qty");
                writer.WriteString("1");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("bench");
                writer.WriteStartAttribute("price");
                writer.WriteString("29.99");
                writer.WriteStartAttribute("qty");
                writer.WriteString("3");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("bench");
                writer.WriteStartAttribute("price");
                writer.WriteString("19.99");
                writer.WriteStartAttribute("qty");
                writer.WriteString("5");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Flush();
                #endregion newWriter

            }
            return "xmlWithDuplicatedProductName.xml";
        }

        public static string XmlWithWrongQuantityDataValue
        {
            get
            {
                return CreateXmlWithWrongQuantityDataValue();
            }
        }

        private static string CreateXmlWithWrongQuantityDataValue()
        {
            XmlWriterSettings settings = GetWriterSettings();
            #region newWriter
            using (XmlWriter writer = XmlWriter.Create("xmlWithWrongQuantityDataValue.xml", settings))
            {
                writer.WriteStartDocument(); // <?xml version="1.0" encoding="utf-16"?>
                writer.WriteStartElement("inventory"); //<Inventory>

                writer.WriteStartElement("products");//<Products>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("table");
                writer.WriteStartAttribute("price");
                writer.WriteString("29.99");
                writer.WriteStartAttribute("qty");
                writer.WriteString("4");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("chair");
                writer.WriteStartAttribute("price");
                writer.WriteString("9.99");
                writer.WriteStartAttribute("qty");
                writer.WriteString("7");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("couch");
                writer.WriteStartAttribute("price");
                writer.WriteString("50");
                writer.WriteStartAttribute("qty");
                writer.WriteString("p");//wrong data type
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("pillow");
                writer.WriteStartAttribute("price");
                writer.WriteString("5");
                writer.WriteStartAttribute("qty");
                writer.WriteString("1");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("bed");
                writer.WriteStartAttribute("price");
                writer.WriteString("255.00");
                writer.WriteStartAttribute("qty");
                writer.WriteString("1");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("bench");
                writer.WriteStartAttribute("price");
                writer.WriteString("29.99");
                writer.WriteStartAttribute("qty");
                writer.WriteString("3");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("stool");
                writer.WriteStartAttribute("price");
                writer.WriteString("19.99");
                writer.WriteStartAttribute("qty");
                writer.WriteString("5");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Flush();
                #endregion newWriter

            }
            return "xmlWithWrongQuantityDataValue.xml";
        }

        public static string XmlWithNullQuantityTag
        {
            get
            {
                return CreateXmlWithNullQuantityTag();
            }
        }

        private static string CreateXmlWithNullQuantityTag()
        {
            XmlWriterSettings settings = GetWriterSettings();
            #region newWriter
            using (XmlWriter writer = XmlWriter.Create("XmlWithNullQuantityTag.xml", settings))
            {
                writer.WriteStartDocument(); // <?xml version="1.0" encoding="utf-16"?>
                writer.WriteStartElement("inventory"); //<Inventory>

                writer.WriteStartElement("products");//<Products>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("table");
                writer.WriteStartAttribute("price");
                writer.WriteString("29.99");
                writer.WriteStartAttribute("qty");
                writer.WriteString("4");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("chair");
                writer.WriteStartAttribute("price");
                writer.WriteString("9.99");
                writer.WriteStartAttribute("qty");
                writer.WriteString("7");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("couch");
                writer.WriteStartAttribute("price");
                writer.WriteString("50");
                //no quantity tag
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("pillow");
                writer.WriteStartAttribute("price");
                writer.WriteString("5");
                writer.WriteStartAttribute("qty");
                writer.WriteString("1");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("bed");
                writer.WriteStartAttribute("price");
                writer.WriteString("255.00");
                writer.WriteStartAttribute("qty");
                writer.WriteString("1");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("bench");
                writer.WriteStartAttribute("price");
                writer.WriteString("29.99");
                writer.WriteStartAttribute("qty");
                writer.WriteString("3");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("stool");
                writer.WriteStartAttribute("price");
                writer.WriteString("19.99");
                writer.WriteStartAttribute("qty");
                writer.WriteString("5");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Flush();
                #endregion newWriter

            }
            return "XmlWithNullQuantityTag.xml";
        }

        public static string XmlWithWrongPriceDataValue
        {
            get
            {
                return CreateXmlWithWrongPriceDataValue();
            }
        }

        private static string CreateXmlWithWrongPriceDataValue()
        {
            XmlWriterSettings settings = GetWriterSettings();
            #region newWriter
            using (XmlWriter writer = XmlWriter.Create("XmlWithWrongPriceDataValue.xml", settings))
            {
                writer.WriteStartDocument(); // <?xml version="1.0" encoding="utf-16"?>
                writer.WriteStartElement("inventory"); //<Inventory>

                writer.WriteStartElement("products");//<Products>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("table");
                writer.WriteStartAttribute("price");
                writer.WriteString("29.99");
                writer.WriteStartAttribute("qty");
                writer.WriteString("4");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("chair");
                writer.WriteStartAttribute("price");
                writer.WriteString("9.99");
                writer.WriteStartAttribute("qty");
                writer.WriteString("7");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("couch");
                writer.WriteStartAttribute("price");
                writer.WriteString("zzz");//wrong data type
                writer.WriteStartAttribute("qty");
                writer.WriteString("2");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("pillow");
                writer.WriteStartAttribute("price");
                writer.WriteString("5");
                writer.WriteStartAttribute("qty");
                writer.WriteString("1");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("bed");
                writer.WriteStartAttribute("price");
                writer.WriteString("255.00");
                writer.WriteStartAttribute("qty");
                writer.WriteString("1");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("bench");
                writer.WriteStartAttribute("price");
                writer.WriteString("29.99");
                writer.WriteStartAttribute("qty");
                writer.WriteString("3");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("stool");
                writer.WriteStartAttribute("price");
                writer.WriteString("19.99");
                writer.WriteStartAttribute("qty");
                writer.WriteString("5");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Flush();
                #endregion newWriter

            }
            return "XmlWithWrongPriceDataValue.xml";
        }

        public static string XmlWithTwoProducts
        {
            get
            {
                return CreateXmlWithTwoProducts();
            }
        }

        private static string CreateXmlWithTwoProducts()
        {
            XmlWriterSettings settings = GetWriterSettings();
            #region newWriter
            using (XmlWriter writer = XmlWriter.Create("xmlWithTwoProducts.xml", settings))
            {
                writer.WriteStartDocument(); // <?xml version="1.0" encoding="utf-16"?>
                writer.WriteStartElement("inventory"); //<Inventory>

                writer.WriteStartElement("products");//<Products>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("table");
                writer.WriteStartAttribute("price");
                writer.WriteString("29.99");
                writer.WriteStartAttribute("qty");
                writer.WriteString("4");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>

                writer.WriteStartElement("product");//<product>
                writer.WriteStartAttribute("name");
                writer.WriteString("chair");
                writer.WriteStartAttribute("price");
                writer.WriteString("9.99");
                writer.WriteStartAttribute("qty");
                writer.WriteString("7");
                writer.WriteEndAttribute();
                writer.WriteEndElement();//</product>            

                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Flush();
                #endregion newWriter

            }
            return "xmlWithTwoProducts.xml";
        }


        private static XmlWriterSettings GetWriterSettings()
        {
            XmlWriterSettings settings = new()
            {
                Indent = true,
                IndentChars = ("    "),
                CloseOutput = true,
                OmitXmlDeclaration = true
            };
            return settings;
        }
    }
}





