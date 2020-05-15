using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLBudgetCalculator.Interfaces
{
    public interface IGenericService<Model> where Model : class
    {
        void Create(Model item);
        void Update(Model item);
        IEnumerable<Model> GetAll();
        void Delete(int id);
        Model GetById(int id);
    }
}
