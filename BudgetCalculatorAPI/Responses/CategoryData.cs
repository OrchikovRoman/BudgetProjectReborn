using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetCalculatorAPI.Responses
{
    public class CategoryData
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }

        public ICollection<OperationData> Operations { get; set; }
    }
}