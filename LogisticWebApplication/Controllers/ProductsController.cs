using System.Collections.Generic;
using Data.Gateway;
using Domain.Gateway;
using Domain.Interactor;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LogisticWebApplication.Controllers {
    [ApiController]
    [Route("/api/products")]
    public class ProductsController : ControllerBase {
        
        private readonly ILogger<StockController> _logger;
        private readonly IAddProductInStockInteractor _addProduct;
        private readonly ILoadProductsInStockInteractor _loadProducts;

        public ProductsController(ILogger<StockController> logger, IAddProductInStockInteractor addProduct, ILoadProductsInStockInteractor loadProducts) {
            _logger = logger;
            _addProduct = addProduct;
            _loadProducts = loadProducts;
        }

        [HttpGet]
        [Route("{stockId}")]
        public IEnumerable<Product> Get(int stockId) {
            return _loadProducts.Execute(stockId);
        }

        [HttpPut]
        [Route("{stockId}")]
        public long Put(long stockId, Product product) {
            return _addProduct.Execute(product, stockId);
        }
    }
}