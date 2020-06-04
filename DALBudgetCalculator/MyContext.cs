using DALBudgetCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DALBudgetCalculator.Migrations.Configuration;

namespace DALBudgetCalculator
{
    public class MyContext : DbContext 
    {
        public MyContext() : base(@"Data Source=.;Initial Catalog=BudgetCalculator;Integrated Security=True")
        {
            Database.SetInitializer<MyContext>(new MyContextInitializer());
        }

        public DbSet<Operation> Operations { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
