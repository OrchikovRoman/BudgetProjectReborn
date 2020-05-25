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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var indexModel = new IndexModel { UserId = User.Identity.GetUserId() };
            return View(indexModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "This application allows you to keep track of your expenses and income. You should no longer take it manually, spend time on it. This budget calculator will do everything for you, and the donut chart will show you your expenses, which will be calculated automatically. You can independently create, edit and delete both operations and categories that you need for simplification and easy navigation. Please note that this application is a demo version, due to the fact that the project was carried out by one person and without funding. Creating this project, as a developer, I learned a very big and vital lesson for myself, you always need to use the GitHub so that you do not have to write first. And in addition, I would like to notice, I wrote it with a great pleasure, dispite many difficulties, but it was worth it. Thanks for watching and taking the time.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact here";

            return View();
        }
    }
}