using System;
using System.Collections.Generic;
using Domain.Interactor;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LogisticWebApplication.Controllers {
    
    [ApiController]
    [Route("/api/stocks")]
    public class StockController : ControllerBase {

        private readonly ILogger<StockController> _logger;
        private readonly IAddStockInteractor _addStock;
        private readonly ILoadStocksInteractor _loadStocks;

        public StockController(ILogger<StockController> logger, IAddStockInteractor addStock, ILoadStocksInteractor loadStocks) {
            _logger = logger;
            _addStock = addStock;
            _loadStocks = loadStocks;
        }

        [HttpGet]
        public IEnumerable<Stock> Get() {
            return _loadStocks.Execute();
        }
        
        [HttpPut]
        public long Put(string city) {
            return _addStock.Execute(city);
        }
        
    }
}