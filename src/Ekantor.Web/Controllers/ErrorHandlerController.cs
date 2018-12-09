using System.Web.Mvc;

namespace Exchange.Web.Controllers
{
    public class ErrorHandlerController : Controller
    {
        // GET: ErrorHandler
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NoPageFound()
        {
            return View();
        }
    }
}