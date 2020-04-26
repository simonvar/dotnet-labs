using System.Collections.Generic;
using Domain.Gateway;
using Domain.Models;

namespace Domain.Interactor {

    public class LoadStocksInteractor {
        private readonly IStocksGateway _gateway;

        public LoadStocksInteractor(IStocksGateway gateway) {
            _gateway = gateway;
        }

        public IEnumerable<Stock> Execute() {
            return _gateway.GetAll();
        }
    }
}