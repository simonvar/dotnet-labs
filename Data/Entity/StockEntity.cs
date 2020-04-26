using System.Collections.Generic;
using Domain.Models;

namespace Data.Entity {
    public class StockEntity {
        public long Id { get; set; }
        
        public string City { get; set; }

        public List<Worker> Workers { get; set; }

        public List<Product> Products { get; set; }
    }
}