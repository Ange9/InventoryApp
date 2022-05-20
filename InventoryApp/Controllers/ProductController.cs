using InventoryApp.BusinessLogic.Interfaces;
using InventoryApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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
        public IEnumerable<Product> Get([FromQuery] string sortingParam)
        {
            return _subjectBL.GetItems(sortingParam);
        }
    }
}