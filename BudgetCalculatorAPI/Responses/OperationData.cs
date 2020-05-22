using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetCalculatorAPI.Responses
{
    public class OperationData
    {
        public int Id { get; set; }
        [MinLength(2), Required]
        public string Description { get; set; }
        [Required]
        public int Amount { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOperation { get; set; }

        public string UserId { get; set; }

        public int CategoryId { get; set; }
        public CategoryData CategoryData { get; set; }
    }
}