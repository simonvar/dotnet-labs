﻿using System.Collections.Generic;
using Domain.Gateway;
using Domain.Models;

namespace Domain.Interactor {
    public interface ILoadProductsInStockInteractor {
        public IEnumerable<Product> Execute(long stockId);
    }
    
    public class LoadProductsInStockInteractor : ILoadProductsInStockInteractor {
        private readonly IProductsGateway _gateway;

        public LoadProductsInStockInteractor(IProductsGateway gateway) {
            _gateway = gateway;
        }

        public IEnumerable<Product> Execute(long stockId) {
            return _gateway.GetInStock(stockId);
        }
    }
}