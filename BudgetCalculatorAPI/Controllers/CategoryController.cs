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
    public class CategoryController : ApiController
    {
        private ICategoryService _service;
        private IMapper _mapper;
        public CategoryController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Category
        public IEnumerable<CategoryData> Get()
        {
            var categoryBL = _service.GetAll();
            var categoryPL = _mapper.Map<IEnumerable<CategoryData>>(categoryBL);
            return categoryPL;
        }

        // GET: api/Category/5
        public CategoryData Get(int id)
        {
            var categoryBL = _service.GetById(id);
            var categoryPL = _mapper.Map<CategoryData>(categoryBL);
            return categoryPL;
        }

        // POST: api/Category
        public void Post([FromBody]CategoryData category)
        {
            var categoryPL = _mapper.Map<CategoryModel>(category);
            _service.Create(categoryPL);
        }

        // PUT: api/Category/5
        [HttpPut]
        public void Put([FromBody]CategoryData category)
        {
            var categoryPL = _mapper.Map<CategoryModel>(category);
            _service.Update(categoryPL);
        }

        // DELETE: api/Category/5
        [HttpDelete]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
