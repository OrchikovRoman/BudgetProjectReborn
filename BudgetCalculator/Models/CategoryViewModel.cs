using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BudgetCalculator.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required, MaxLength(500), MinLength(2)]
        public string Name { get; set; }
        public string Image { get; set; }

        public ICollection<OperationViewModel> Operations { get; set; }
    }
}