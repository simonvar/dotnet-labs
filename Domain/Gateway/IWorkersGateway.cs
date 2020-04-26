using System.Collections.Generic;
using Domain.Models;

namespace Domain.Gateway {
    public interface IWorkersGateway {
        List<Worker> GetInStock(long stockId);

        long AddInStock(Worker worker, long stockId);
    }
}