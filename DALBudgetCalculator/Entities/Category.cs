using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALBudgetCalculator.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public ICollection<Operation> Operations { get; set; }

        public Category()
        {
            Operations = new List<Operation>();
        }
    }
}
