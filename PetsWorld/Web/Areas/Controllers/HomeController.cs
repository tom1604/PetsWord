using System.Web.Mvc;

namespace Web.Areas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Areas/Views/Home/Index.cshtml");
        }
    }
}