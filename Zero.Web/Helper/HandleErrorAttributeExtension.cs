using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Zero.Web.Helper
{
    public class HandleErrorAttributeExtension : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            var model = new HandleErrorInfo(ex, 
                filterContext.RouteData.Values["controller"].ToString(), 
                filterContext.RouteData.Values["action"].ToString());

            filterContext.Result = new ViewResult()
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(model)
            };

            //base.OnException(filterContext);
        }
    }
}
