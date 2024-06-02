﻿using Domain.common;

namespace Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public decimal Price { get; set; }
        //public string Fname { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
