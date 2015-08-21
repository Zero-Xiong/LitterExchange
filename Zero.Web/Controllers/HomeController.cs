using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero.Data;
using Zero.Model;
using Zero.Resource;

namespace Zero.Web.Controllers
{
    public class HomeController : Controller
    {
        LitterDbContext _dbContext = new LitterDbContext();

        public ActionResult Index()
        {
            var list = _dbContext.Categorys.ToList();
            
            return View(list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}