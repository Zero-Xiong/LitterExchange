using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero.Model;
using Zero.Data;
using Zero.Web.ViewModels;

namespace Zero.Web.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        private IEnumerable<Category> GetCategories()
        {
            LitterDbContext _dbContext = new LitterDbContext();
            return _dbContext.Categorys;
        }

        public ActionResult RenderCategoryPartialView(string categoryId)
        {
            var list = this.GetCategories().ToList();

            return PartialView("CategoryList", new CategoryList() { ActivedCategoryId = categoryId, Categories = list });
        }
    }
}