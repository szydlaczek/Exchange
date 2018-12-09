using Exchange.Infrastructure.Commands;
using Exchange.Infrastructure.ViewModels;
using Exchange.Web.Filters;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Exchange.Web.Controllers
{
    public class StartController : BaseController
    {
        public StartController(IMediator mediator) : base(mediator)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogIn(string returnUrl)
        {
            if (!Request.IsAuthenticated)
            {
                ViewBag.ReturnUrl = returnUrl;
                return View(new LogInViewModel());
            }
            else
                return RedirectToAction(nameof(ApplicationController.MainPage), nameof(ApplicationController).Replace("Controller", string.Empty));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateModel]
        public async Task<ActionResult> LogIn(LogInViewModel logInViewModel, string returnUrl)
        {
            var result = await _mediatorBus.Send(new LogInCommand { LogInViewModel = logInViewModel });
            if (result.Succeeded == true)
            {
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return RedirectPermanent("~" + returnUrl);
                }
                string p = Request.UrlReferrer.AbsolutePath;
                return RedirectToAction("MainPage", "Application");
            }
            else
            {
                ModelState.AddModelError("", string.Join(",", result.Errors.Select(s => s)));
                return View(logInViewModel);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("MainPage", "Application");
        }
    }
}