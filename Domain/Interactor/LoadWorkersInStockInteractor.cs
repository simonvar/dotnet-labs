using System.Collections.Generic;
using Domain.Gateway;
using Domain.Models;

namespace Domain.Interactor {
    public class LoadWorkersInStockInteractor {
        private readonly IWorkersGateway _gateway;

        public LoadWorkersInStockInteractor(IWorkersGateway gateway) {
            _gateway = gateway;
        }

        public IEnumerable<Worker> Execute(long stockId) {
            return _gateway.GetInStock(stockId);
        }
    }
}