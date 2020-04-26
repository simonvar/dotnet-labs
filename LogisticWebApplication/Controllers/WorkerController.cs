using System.Collections.Generic;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LogisticWebApplication.Controllers {
    
    [ApiController]
    [Route("/api/workers")]
    public class WorkerController : ControllerBase {

        private readonly ILogger<StockController> _logger;

        public WorkerController(ILogger<StockController> logger) {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Worker> Get() {
           return new List<Worker>();
        }
        
        [HttpGet]
        [Route("{stockId}")]
        public IEnumerable<Worker> Get(int stockId) {
            return new List<Worker>();
        }
        
    }
}