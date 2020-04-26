using System.Collections.Generic;
using Domain.Gateway;
using Domain.Models;

namespace Domain.Interactor {

    public interface ILoadStocksInteractor {
        public IEnumerable<Stock> Execute();
    }
    
    public class LoadStocksInteractor : ILoadStocksInteractor {
        private readonly IStocksGateway _gateway;

        public LoadStocksInteractor(IStocksGateway gateway) {
            _gateway = gateway;
        }

        public IEnumerable<Stock> Execute() {
            return _gateway.GetAll();
        }
    }
}