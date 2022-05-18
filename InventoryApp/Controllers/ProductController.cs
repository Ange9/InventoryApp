using InventoryApp.BusinessLogic;
using InventoryApp.BusinessLogic.Interfaces;
using InventoryApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryApp.Controllers
{
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IItemBL<Product> _itemBL; 

        private ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, IItemBL<Product> itemBL)
        {
            this._logger = logger;
            _itemBL = itemBL;

        }

        public IEnumerable<Product> GetProducts(int sorting)
        {
            return _itemBL.GetItems(sorting);
        }
    }
}