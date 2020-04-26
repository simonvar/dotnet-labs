using System.Collections.Generic;
using Domain.Gateway;
using Domain.Models;

namespace Domain.Interactor {
    public interface ILoadWorkersInStockInteractor {
        public IEnumerable<Worker> Execute(long stockId);
    }

    public class LoadWorkersInStockInteractor : ILoadWorkersInStockInteractor {
        private readonly IWorkersGateway _gateway;

        public LoadWorkersInStockInteractor(IWorkersGateway gateway) {
            _gateway = gateway;
        }

        public IEnumerable<Worker> Execute(long stockId) {
            return _gateway.GetInStock(stockId);
        }
    }
}