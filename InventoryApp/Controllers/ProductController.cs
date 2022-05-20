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
        private readonly ISubjectBL<Product> _subjectBL; 

        private ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, ISubjectBL<Product> subject)
        {
            this._logger = logger;
            _subjectBL = subject;

        }
        [HttpGet]
        public IEnumerable<Product> Get(string sorting)
        {
            var v = _subjectBL.GetItems("0");
            return v;
        }
    }
}