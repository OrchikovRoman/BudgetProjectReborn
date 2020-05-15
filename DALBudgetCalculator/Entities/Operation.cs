﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALBudgetCalculator.Entities
{
    public class Operation
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public DateTime DateOperation { get; set; }
        
        public int UserId { get; set; }
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
