using Domain.Gateway;
using Domain.Models;

namespace Domain.Interactor {

    public interface IAddWorkerInStockInteractor {
        public long Execute(Worker worker, long stockId);
    }
    
    public class AddWorkerInStockInteractor : IAddWorkerInStockInteractor{
        private readonly IWorkersGateway _gateway;
        
        public AddWorkerInStockInteractor(IWorkersGateway gateway) {
            _gateway = gateway;
        }

        public long Execute(Worker worker, long stockId) {
            return _gateway.AddInStock(worker, stockId);
        }
    }
}