﻿using System.Collections.Generic;

namespace SuperMarket.API.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }
        
        public int CategoryId { get; set; }
        public  Category Category { get; set; }
        
        public List<ProductTag>ProductTags { get; set; }
    }
}