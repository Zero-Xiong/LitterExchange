using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero.Model;
using Zero.Resource;
using System.Data.Entity.Infrastructure;
using System.Data;
using System.Data.Entity;
using Zero.Common;
using Zero.Service;
using Zero.Web.Core.Extensions;
using Zero.Web.Core.ViewModels;

namespace Zero.Web.Controllers
{
    [HandleErrorAttributeExtension]
    public class HomeController : Controller
    {
        private readonly ICategoryService catService = new CategoryService();
        private readonly IItemService itemService = new ItemService();
        private readonly ISysLog log = SysLog.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //public HomeController(ISysLog _log, 
        //    ICategoryService _catService,
        //    IItemService _itemService)
        //{
        //    this.catService = _catService;
        //    this.itemService = _itemService;
        //    this.log 
        //}

        public ActionResult Index(string activedCategoryId)
        {
            log.Info("Home Index");

            IList<Category> catList = catService.GetCategoriesByDefaultSorting().ToList();
            IList<Item> itemList = null;

            if (!string.IsNullOrWhiteSpace(activedCategoryId))

                itemList = itemService.GetItemsByCategoryPage(activedCategoryId, 0, int.MaxValue, string.Empty, string.Empty).ToList();

            else
                itemList = itemService.GetItemsByPage(0, int.MaxValue, string.Empty, string.Empty).ToList();

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