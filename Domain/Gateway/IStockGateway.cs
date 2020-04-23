using System.Collections.Generic;

namespace Domain.Gateway {
    public interface IStockGateway {
        List<Stock> GetAll();
    }
}