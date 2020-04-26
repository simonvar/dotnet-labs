using System.Collections.Generic;
using Domain.Interactor;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LogisticWebApplication.Controllers {
    
    [ApiController]
    [Route("/api/workers")]
    public class WorkerController : ControllerBase {

        private readonly ILogger<StockController> _logger;
        private readonly IAddWorkerInStockInteractor _addWorker;
        private readonly ILoadWorkersInStockInteractor _loadWorkers;
        
        public WorkerController(ILogger<StockController> logger, IAddWorkerInStockInteractor addWorker, ILoadWorkersInStockInteractor loadWorkers) {
            _logger = logger;
            _addWorker = addWorker;
            _loadWorkers = loadWorkers;
        }

        [HttpGet]
        [Route("{stockId}")]
        public IEnumerable<Worker> Get(int stockId) {
            return _loadWorkers.Execute(stockId);
        }

        [HttpPut]
        [Route("{stockId}")]
        public long Put(long stockId, Worker product) {
            return _addWorker.Execute(product, stockId);
        }
    }
}