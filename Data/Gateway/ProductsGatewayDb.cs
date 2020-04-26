using System.Collections.Generic;
using System.Linq;
using Domain.Gateway;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Gateway {
    public class ProductsGatewayDb : IProductsGateway {
        private readonly LogisticDbContext _context;

        public ProductsGatewayDb(LogisticDbContext context) {
            _context = context;
        }
        
        public List<Product> GetInStock(long stockId) {
            return _context.Set<Stock>()
                .Include(it => it.Products)
                .FirstOrDefaultAsync(it => it.Id == stockId)
                .Result.Products.ToList();
        }

        public long AddInStock(Product product, long stockId) {
            var stock = _context.Set<Stock>()
                .Include(it => it.Products)
                .FirstOrDefaultAsync(it => it.Id == stockId).Result;

            var lastId = stock.Products.Last().Id;
            product.Id = lastId + 1;
            
            stock.Products.Add(product);
            _context.Entry(stock).State = EntityState.Modified;
            
            _context.SaveChanges();
            return product.Id;
        }
    }
}