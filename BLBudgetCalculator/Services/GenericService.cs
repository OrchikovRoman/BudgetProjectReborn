using BLBudgetCalculator.Interfaces;
using DALBudgetCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLBudgetCalculator.Services
{
    public abstract class GenericService<BlModel, DALModel> : IGenericService<BlModel>
        where BlModel : class
        where DALModel : class
    {
        private readonly IGenericRepository<DALModel> _repository;
        public GenericService(IGenericRepository<DALModel> repository)
        {
            _repository = repository;
        }

        public void Create(BlModel item)
        {
            var model = Map(item);
            _repository.Create(model);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<BlModel> GetAll()
        {
            var listEntity = _repository.GetAll().ToList();
            return Map(listEntity);
        }

        public BlModel GetById(int id)
        {
            var model = _repository.GetById(id);
            return Map(model);
        }

        public void Update(BlModel item)
        {
            var model = Map(item);
            _repository.Update(model);
        }

        public abstract BlModel Map(DALModel entity);
        public abstract DALModel Map(BlModel blmodel);
        public abstract IEnumerable<BlModel> Map(IList<DALModel> entities);
        public abstract IEnumerable<DALModel> Map(IList<BlModel> models);

    }
}
