using System.Web.Mvc;
using PunchIt.SignalR;

namespace PunchIt.Controllers
{
    public class HomeController : Controller
    {
        // GET: Punch
        public ActionResult Index()
        {
            ViewBag.Members = PunchHub.Connections;

            return View();
        }

        public ActionResult Punch()
        {
            return View("Index");
        }
    }
}