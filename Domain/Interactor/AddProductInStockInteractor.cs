using Domain.Gateway;
using Domain.Models;

namespace Domain.Interactor {
    public interface IAddProductInStockInteractor {
        public long Execute(Product product, long stockId);
    }
    
    public class AddProductInStockInteractor : IAddProductInStockInteractor {
        private readonly IProductsGateway _gateway;
        
        public AddProductInStockInteractor(IProductsGateway gateway) {
            _gateway = gateway;
        }

        public long Execute(Product product, long stockId) {
            return _gateway.AddInStock(product, stockId);
        }
    }
}