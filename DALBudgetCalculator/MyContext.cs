using DALBudgetCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALBudgetCalculator
{
    public class MyContext : DbContext 
    {
        static MyContext()
        {
            Database.SetInitializer<MyContext>(new MyContextInit());
        }
        public MyContext() : base(@"Data Source=.;Initial Catalog=BudgetCalculator;Integrated Security=True")
        {
            Configuration.LazyLoadingEnabled = true;
        }


        public DbSet<Operation> Operations { get; set; }
        public DbSet<Category> Categories { get; set; }

        class MyContextInit : CreateDatabaseIfNotExists<MyContext>
        {
            protected override void Seed(MyContext context)
            {
                context.Operations.Add(new Operation { Id = 1, Description = "Admin" });
                context.Operations.Add(new Operation { Id = 2, Description = "Roman Orchikov" });
                context.Operations.Add(new Operation { Id = 3, Description = "Humanoid" });
                context.Operations.Add(new Operation { Id = 4, Description = "Auto" });

                context.Categories.Add(new Category { Id = 1, Name = "News" });
                context.Categories.Add(new Category { Id = 2, Name = "Porno News" });
                context.Categories.Add(new Category { Id = 3, Name = "Other" });
                context.Categories.Add(new Category { Id = 4, Name = "Auto" });
                context.Categories.Add(new Category { Id = 5, Name = "Main" });

            }
        }
    }
}
