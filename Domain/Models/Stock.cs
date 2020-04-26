using System.Collections.Generic;

namespace Domain.Models {
    public class Stock {
        public long Id { set; get; }

        public string City;
        
        public HashSet<Product> Products { set; get; }
        
        public HashSet<Worker> Workers { set; get; }
    }
}