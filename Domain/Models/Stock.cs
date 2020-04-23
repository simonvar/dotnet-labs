﻿using System.Collections.Generic;

namespace Domain.Models {
    public class Stock {
        public long Id { set; get; }

        public string City;
        
        public HashSet<Section> Sections { set; get; }
    }
}