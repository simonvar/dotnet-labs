using System.Collections.Generic;
using Domain.Gateway;
using Domain.Models;

namespace Domain.Interactor {

    public interface IAddStockInteractor {
        public long Execute(string city);
    }
    
    public class AddStockInteractor : IAddStockInteractor {
        private readonly IStocksGateway _gateway;
        public AddStockInteractor(IStocksGateway gateway) {
            _gateway = gateway;
        }

        public long Execute(string city) {
            return _gateway.AddStock(city);
        }
    }
}