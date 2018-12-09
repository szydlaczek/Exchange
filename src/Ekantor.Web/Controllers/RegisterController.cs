using Exchange.Infrastructure.Commands;
using Exchange.Infrastructure.ViewModels;
using MediatR;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Exchange.Web.Controllers
{
    public class RegisterController : BaseController
    {
        public RegisterController(IMediator mediatorBus) : base(mediatorBus)
        {
        }

        public ActionResult NewUser()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewUser(RegisterViewModel registerUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediatorBus.Send(new RegisterUserCommand
                {
                    NewUser = registerUserViewModel
                });
                if (result.Succeeded)
                {
                    TempData["AccountCreated"] = "You have created account, please log in";
                    return RedirectToAction(nameof(RegisterController.Info), nameof(RegisterController).Replace("Controller", string.Empty));
                }
                else
                {
                    ModelState.AddModelError("", string.Join(", ", result.Errors.ToArray()));
                    return View(registerUserViewModel);
                }
            }
            else
                return View();
        }

        public ActionResult Info()
        {
            ViewBag.Info = TempData["AccountCreated"].ToString();
            return View();
        }
    }
}