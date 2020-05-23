using AutoMapper;
using BLBudgetCalculator.Interfaces;
using BLBudgetCalculator.Models;
using BudgetCalculator.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BudgetCalculator.Controllers
{
    [Authorize]
    public class OperationController : Controller
    {
        private readonly IOperationService _service;
        private IMapper _mapper;

        public OperationController(IOperationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: Operation
        public ActionResult Index()
        {
            var value = User.Identity.GetUserId();
            var operationBL = _service.GetAll().ToList();
            var operationsFilter = operationBL.Where(x => x.UserId == value || x.UserId == null);
            var operationPL = _mapper.Map<IEnumerable<OperationViewModel>>(operationsFilter); 
            return View(operationPL);
        }

        // GET: Operation/Details/5
        public ActionResult Details(int id)
        {
            var operationBL = _service.GetById(id);
            var operationPL = _mapper.Map<OperationViewModel>(operationBL);

            return View(operationPL);
        }

        // GET: Operation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Operation/Create
        [HttpPost]
        public ActionResult Create(OperationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var modelBL = _mapper.Map<OperationModel>(model);
            _service.Create(modelBL);
            return RedirectToAction("Index");
        }

        // GET: Operation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Operation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OperationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var modelBL = _mapper.Map<OperationModel>(model);
            _service.Update(modelBL);
            return RedirectToAction("Index");
        }

        // GET: Operation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Operation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, OperationViewModel model)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
