using System.Web.Mvc;

namespace SignalRPlay.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Chat()
		{
			return View();
		}
	}
}