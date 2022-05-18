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
    [ApiController]
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
        [HttpGet]

        public IEnumerable<Product> Get(int sorting=0)
        {
            var v = _itemBL.GetItems(sorting).ToArray();
            return v;
        }
    }
}