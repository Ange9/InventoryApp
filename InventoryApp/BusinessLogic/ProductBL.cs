using InventoryApp.BusinessLogic.Interfaces;
using InventoryApp.DataAccess.Interfaces;
using InventoryApp.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;

namespace InventoryApp.BusinessLogic
{
    public class ProductBL : ISubjectBL<Product>
    {
		private readonly IXMLReader<Product> _productXMLReader;
		private ILogger<ProductBL> _logger;

		public ProductBL(IXMLReader<Product> productXMLReader, ILogger<ProductBL> logger) {
			_productXMLReader = productXMLReader;
			_logger = logger;
		}

		public List<Product> GetItems(string sorting)
		{
			List<Product> products= new();
			try {
				products = _productXMLReader.ReadXML(sorting);
			}
			catch (FileNotFoundException) {
				_logger.LogError("File not found");
			}
			catch (Exception ex)
			{
				_logger.LogError("Error trying to read from excel file"+ ex.Message);
			}
			return products;
		}

    }
}