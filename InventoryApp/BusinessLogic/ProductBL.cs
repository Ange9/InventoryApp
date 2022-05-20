using InventoryApp.BusinessLogic.Interfaces;
using InventoryApp.DataAccess.Interfaces;
using InventoryApp.Entities;
using InventoryApp.Enums;
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

		public List<Product> GetItems(SortParameter sorting)
		{
			List<Product> products= new();
			try {
				products = _productXMLReader.ReadXML(sorting);
			}
			catch (FileNotFoundException ex) {
				_logger.LogError(ex.Message);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
			}
			return products;
		}
    }
}