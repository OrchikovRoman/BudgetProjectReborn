using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLBudgetCalculator.Models
{
    public class OperationModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public DateTime DateOperation { get; set; }

        public string UserId { get; set; }

        public int CategoryId { get; set; }
        public CategoryModel CategoryModel { get; set; }
    }
}
