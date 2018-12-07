using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Exchange.Web.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.Controller.ViewData.ModelState.IsValid)
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //filterContext.HttpContext.Response.Redirect()
            }
        }
    }
}