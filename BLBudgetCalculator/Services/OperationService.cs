using AutoMapper;
using BLBudgetCalculator.Interfaces;
using BLBudgetCalculator.Models;
using DALBudgetCalculator.Entities;
using DALBudgetCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLBudgetCalculator.Services
{
    public class OperationService : GenericService<OperationModel, Operation>, IOperationService
    {
        private IMapper _mapper;

        public OperationService(IGenericRepository<Operation> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public override OperationModel Map(Operation entity)
        {
            return _mapper.Map<OperationModel>(entity);
        }

        public override Operation Map(OperationModel blmodel)
        {
            return _mapper.Map<Operation>(blmodel);
        }

        public override IEnumerable<OperationModel> Map(IList<Operation> entities)
        {
            return _mapper.Map<IEnumerable<OperationModel>>(entities);
        }

        public override IEnumerable<Operation> Map(IList<OperationModel> models)
        {
            return _mapper.Map<IEnumerable<Operation>>(models);
        }
    }
}
