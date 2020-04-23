using System.Collections.Generic;
using Domain.Gateway;

namespace Domain.Interactor {

    public class LoadStocksInteractor {

        private readonly IStockGateway _gateway;

        public LoadStocksInteractor(IStockGateway gateway) {
            _gateway = gateway;
        }

        public IEnumerable<Stock> Execute() {
            return _gateway.GetAll();
        }
    }
}