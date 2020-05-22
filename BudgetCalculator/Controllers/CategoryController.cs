using AutoMapper;
using BLBudgetCalculator.Interfaces;
using BLBudgetCalculator.Models;
using BudgetCalculator.Models;
using Microsoft.AspNet.Identity; //ДЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩЩ
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BudgetCalculator.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        private IMapper _mapper;
        public CategoryController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: Category
        public ActionResult Index()
        {
            var categoriesBL = _service.GetAll().ToList();
            var categoriesPL = _mapper.Map<IEnumerable<CategoryViewModel>>(categoriesBL);

            return View(categoriesPL);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var categoriesBL = _service.GetById(id);
            var categoriesPL = _mapper.Map<CategoryViewModel>(categoriesBL);

            return View(categoriesPL);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            var userId = User.Identity.GetUserId();
            model.Image = userId;
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var modelBL = _mapper.Map<CategoryModel>(model);
            _service.Create(modelBL);
            return RedirectToAction("Index");
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var modelBL = _mapper.Map<CategoryModel>(model);
            _service.Update(modelBL);

            return RedirectToAction("Index");
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CategoryViewModel model)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
