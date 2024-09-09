using Microsoft.AspNetCore.Mvc;

namespace TesteTecnicoTechNation.WebUI.Controllers
{
	public class DashboardController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
