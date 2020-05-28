using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetCalculator.Models
{
    public class OperationViewModel
    {
        public int Id { get; set; }
        [MinLength(2), MaxLength(500), Required]
        public string Description { get; set; }
        [Required]
        public int Amount { get; set; }
        
        [DataType(DataType.Date), Required]
        public DateTime DateOperation { get; set; }

        public string UserId { get; set; }

        public int CategoryId { get; set; }
        public CategoryViewModel CategoryViewModel { get; set; }
    }
}