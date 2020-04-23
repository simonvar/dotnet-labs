using System.Collections.Generic;

namespace Domain.Models {
    public class Section {
        
        public long Id { set; get; }
        
        public HashSet<Product> Products { set; get; }
    }
}