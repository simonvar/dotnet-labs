using System.Collections.Generic;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LogisticWebApplication.Controllers {
    
    [ApiController]
    [Route("/api/products")]
    public class ProductsController : ControllerBase {
        
        private readonly ILogger<StockController> _logger;

        public ProductsController(ILogger<StockController> logger) {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get() {
            return new List<Product>();
        }
        
        [HttpGet]
        [Route("{stockId}")]
        public IEnumerable<Product> Get(int stockId) {
            return new List<Product>();
        }
        
    }
}