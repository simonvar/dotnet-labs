using System.Collections.Generic;
using Domain.Gateway;
using Domain.Models;

namespace Domain.Interactor {
    public class AddStockInteractor {
        private readonly IStocksGateway _gateway;
        public AddStockInteractor(IStocksGateway gateway) {
            _gateway = gateway;
        }

        public long Execute(string city) {
            return _gateway.AddStock(city);
        }
    }
}