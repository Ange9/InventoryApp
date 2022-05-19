using InventoryApp.BusinessLogic.Interfaces;
using InventoryApp.DataAccess;
using InventoryApp.DataAccess.Interfaces;
using InventoryApp.Entities;
using System;
using System.Collections.Generic;

namespace InventoryApp.BusinessLogic
{
    public class ProductBL : ISubjectBL<Product>
    {
		private readonly IXMLReader<Product> _productXMLReader;

		public ProductBL(IXMLReader<Product> productXMLReader) {
			_productXMLReader = productXMLReader;
		}

		public IEnumerable<Product> GetItems(string sorting)
		{
			return _productXMLReader.ReadXML(sorting);
		}

		

		

        

    }
}