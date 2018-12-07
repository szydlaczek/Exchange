using MediatR;
using System.Web.Mvc;

namespace Exchange.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IMediator _mediatorBus;

        public BaseController(IMediator mediatorBus)
        {
            _mediatorBus = mediatorBus;
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = this.Json(new {
                    Succeeded = false,
                    Message = "Something goes wron, pleas try again later"
                });
            }
            filterContext.Result = RedirectToAction("Index", "ErrorHandler");
            //base.OnException(filterContext);
        }
    }
}