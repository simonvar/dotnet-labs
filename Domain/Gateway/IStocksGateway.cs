using System;
using System.Collections.Generic;
using Domain.Models;

namespace Domain.Gateway {
    public interface IStocksGateway {
        List<Stock> GetAll();
        long AddStock(string city);
    }
}