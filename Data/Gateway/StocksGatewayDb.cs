using System.Collections.Generic;
using System.Linq;
using Domain.Gateway;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Gateway {
    
    public class StocksGatewayDb : IStocksGateway {
        private readonly LogisticDbContext _context;

        public StocksGatewayDb(LogisticDbContext context) {
            _context = context;
        }

        public List<Stock> GetAll() {
            return _context.Set<Stock>()
                .Include(it => it.Products)
                .Include(it => it.Workers)
                .ToList();
        }

        public long AddStock(string city) {
            var stocks = _context.Set<Stock>();

            var lastId = stocks.Last().Id;

            var newStock = new Stock {
                Id = lastId,
                City = city
            };
        
            stocks.Add(newStock);
            _context.Entry(newStock).State = EntityState.Modified;
        
            _context.SaveChanges();
            return lastId;
        }
    }
}