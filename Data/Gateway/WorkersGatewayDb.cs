using System.Collections.Generic;
using System.Linq;
using Domain.Gateway;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Gateway {
    public class WorkersGatewayDb: IWorkersGateway {
        private readonly LogisticDbContext _context;

        public WorkersGatewayDb(LogisticDbContext context) {
            _context = context;
        }
        
        public List<Worker> GetInStock(long stockId) {
            return _context.Set<Stock>()
                .Include(it => it.Workers)
                .FirstOrDefaultAsync(it => it.Id == stockId)
                .Result.Workers.ToList();
        }

        public long AddInStock(Worker worker, long stockId) {
            var stock = _context.Set<Stock>()
                .Include(it => it.Workers)
                .FirstOrDefaultAsync(it => it.Id == stockId).Result;

            var lastId = stock.Products.Last().Id;
            worker.Id = lastId + 1;
            
            stock.Workers.Add(worker);
            _context.Entry(stock).State = EntityState.Modified;
            
            _context.SaveChanges();
            return worker.Id;
        }
    }
}