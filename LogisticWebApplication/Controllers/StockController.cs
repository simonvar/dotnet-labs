using System;
using System.Collections.Generic;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LogisticWebApplication.Controllers {
    
    [ApiController]
    [Route("/api/stocks")]
    public class StockController : ControllerBase {

        private readonly ILogger<StockController> _logger;

        public StockController(ILogger<StockController> logger) {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Stock> Get() {
            return new List<Stock>();
        }
        
    }
}