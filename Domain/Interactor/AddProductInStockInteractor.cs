using Domain.Gateway;
using Domain.Models;

namespace Domain.Interactor {
    public class AddProductInStockInteractor {
        private readonly IProductsGateway _gateway;
        
        public AddProductInStockInteractor(IProductsGateway gateway) {
            _gateway = gateway;
        }

        public long Execute(Product product, long stockId) {
            return _gateway.AddInStock(product, stockId);
        }
    }
}