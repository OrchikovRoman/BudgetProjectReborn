using AutoMapper;
using BLBudgetCalculator.Interfaces;
using BLBudgetCalculator.Models;
using BudgetCalculatorAPI.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BudgetCalculatorAPI.Controllers
{
    public class OperationController : ApiController
    {
        private IOperationService _service;

        private IMapper _mapper;

        public OperationController(IOperationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public OperationController() { }

        // GET: api/Operation
        public IEnumerable<OperationData> Get()
        {
            var operationBL = _service.GetAll();
            var operationPL = _mapper.Map<IEnumerable<OperationData>>(operationBL);
            return operationPL;
        }

        // GET: api/Operation/5
        public OperationData Get(int id)
        {
            var operationBL = _service.GetById(id);
            var operationPL = _mapper.Map<OperationData>(operationBL);
            return operationPL;
        }

        // POST: api/Operation
        [HttpPost]
        public void Post([FromBody]OperationData model)
        {
            var operationPL = _mapper.Map<OperationModel>(model);
            _service.Create(operationPL);
        }

        // PUT: api/Operation/5
        [HttpPut]
        public void Put([FromBody]OperationData model)
        {
            var operationPL = _mapper.Map<OperationModel>(model);
            _service.Update(operationPL);
        }

        // DELETE: api/Operation/5
        [HttpDelete]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
