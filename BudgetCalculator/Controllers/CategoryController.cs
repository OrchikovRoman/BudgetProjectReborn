using AutoMapper;
using BLBudgetCalculator.Interfaces;
using BLBudgetCalculator.Models;
using BudgetCalculator.Models;
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
        public ActionResult Create(CategoryViewModel model, HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте
                upload.SaveAs(Server.MapPath("~/Resourses/" + fileName));
                model.Image = fileName;
            }

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
            var category = _service.GetById(id);
            var model = _mapper.Map<CategoryViewModel>(category);
            return View(model);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoryViewModel model, HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте
                upload.SaveAs(Server.MapPath("~/Resourses/" + fileName));
                model.Image = fileName;
            }
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
            var category = _service.GetById(id);
            var model = _mapper.Map<CategoryViewModel>(category);
            return View(model);
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
