using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero.Data;
using Zero.Model;
using Zero.Resource;
using System.Data.Entity.Infrastructure;
using System.Data;
using System.Data.Entity;
using Zero.Web.ViewModels;
using Zero.Web.Helper;
using Zero.Common;

namespace Zero.Web.Controllers
{
    [HandleErrorAttributeExtension]
    public class HomeController : Controller
    {
        LitterDbContext _dbContext = new LitterDbContext();
        ISysLog log = SysLog.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ActionResult Index(string activedCategoryId)
        {
            log.Info("Home Index");

            IList<Category> catList = _dbContext.Categorys.OrderBy(c => new { c.Sequence, c.Name }).ToList();
            IList<Item> itemList = null;

            if (!string.IsNullOrWhiteSpace(activedCategoryId))
                itemList = _dbContext.Items
                    //.Include(i => i.Categories.Where(c => c.Id.ToString() == activedCategoryId))
                    .ToList();
            else
                itemList = _dbContext.Items
                    .ToList();

            HomeIndexViewModel viewModel = new HomeIndexViewModel()
            {
               Category = new CategoryList() { ActivedCategoryId = activedCategoryId, Categories = catList },
               Items = itemList 
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

    }
}