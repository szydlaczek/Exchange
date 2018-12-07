using Exchange.Infrastructure.Commands;
using Exchange.Infrastructure.Queries;
using Exchange.Infrastructure.ViewModels;
using MediatR;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Exchange.Web.Controllers
{
    [Authorize]
    public class ApplicationController : BaseController
    {
        // GET: Application
        public ApplicationController(IMediator mediatorBus) : base(mediatorBus)
        {
            
        }

        public async Task<ActionResult> MainPage()
        {
            var result = await _mediatorBus.Send(new SystemCurrenciesQuery());
            
            return View();
        }

        public async Task<ActionResult> GetCurrentValues()
        {
            var result = await _mediatorBus.Send(new SystemCurrenciesQuery());
            return PartialView("~/Views/Shared/SystemCurrenciesPartial.cshtml", result.Data);
        }

        public async Task<ActionResult> GetUserWallet()
        {
            var userId = User.Identity.GetUserId();
            var result = await _mediatorBus.Send(new UserCurrenciesQuery(userId));
            return PartialView("~/Views/Shared/UserWalletPartial.cshtml", result.Data);
        }

        public ActionResult ShowPurchaseForm(int? currencyId)
        {
            var purchaseViewModel = new PurchaseCurrencyViewModel();
            purchaseViewModel.CurrencyId = (int)currencyId; 
            return PartialView("PurchaseForm", purchaseViewModel);
        }

        public ActionResult ShowSellForm(int? currencyId)
        {
            var sellCurrencyViewModel = new SellCurrencyViewModel();
            sellCurrencyViewModel.CurrencyId = (int)currencyId;
            return PartialView("SellForm", sellCurrencyViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Purchase(PurchaseCurrencyViewModel purchaseViewModel)
        {
            await _mediatorBus.Send(new UpdateValuesFromApiCommand());
            var result = await _mediatorBus.Send(new PurchaseCurrencyCommand
            {
                UserId = User.Identity.GetUserId(),
                Data = purchaseViewModel
            });
            return this.Json(new
            {
                Succeeded = result.Succeeded,
                Message=result.Succeeded==false ? result.Errors.FirstOrDefault() : string.Empty
            });
        }

        [HttpPost]
        public async Task<ActionResult> SellCurrency(SellCurrencyViewModel purchaseViewModel)
        {
            await _mediatorBus.Send(new UpdateValuesFromApiCommand());
            var result = await _mediatorBus.Send(new SellCurrencyCommand
            {
                UserId = User.Identity.GetUserId(),
                Data = purchaseViewModel
            });
            return this.Json(new
            {
                Succeeded = result.Succeeded,
                Message = result.Succeeded == false ? result.Errors.FirstOrDefault() : string.Empty
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogOff()
        {
            await _mediatorBus.Send(new LogOffCommand());

            return RedirectToAction(nameof(StartController.LogIn), nameof(StartController).Replace("Controller", string.Empty));
        }
    }
}