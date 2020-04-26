using System.Collections.Generic;
using Domain.Models;

namespace Domain.Gateway {
    public interface IProductsGateway {
        List<Product> GetInStock(long stockId);

        long AddInStock(Product product, long stockId);
    }
}