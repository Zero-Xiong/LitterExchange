using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero.Common;
using Zero.Model;
using Zero.Service;
using Zero.Web.Core.ViewModels;

namespace Zero.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService catService = new CategoryService();
        private readonly ISysLog log = SysLog.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        private IEnumerable<Category> GetCategories()
        {
            return catService.GetCategoriesByDefaultSorting();
        }

        public ActionResult RenderCategoryPartialView(string categoryId)
        {
            var list = this.GetCategories().ToList();

            return PartialView("CategoryList", new CategoryList() { ActivedCategoryId = categoryId, Categories = list });
        }
    }
}