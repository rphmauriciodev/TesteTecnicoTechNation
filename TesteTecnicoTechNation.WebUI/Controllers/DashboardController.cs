using Microsoft.AspNetCore.Mvc;
using TesteTecnicoTechNation.Application.Interfaces;
using TesteTecnicoTechNation.WebUI.Models;

namespace TesteTecnicoTechNation.WebUI.Controllers
{
	public class DashboardController : Controller
	{
		private readonly IDadosFaturamentoService _dadosFaturamentoService;

		public DashboardController(IDadosFaturamentoService dadosFaturamentoService)
		{
			_dadosFaturamentoService = dadosFaturamentoService;
		}
		public async Task<IActionResult> Index()
		{
			var dashboardData = new DashboardDataViewModel
			{
				totalAVencer = await _dadosFaturamentoService.GetTotalAVencer(),
				total = await _dadosFaturamentoService.GetTotal(),
				dadosGerais = await _dadosFaturamentoService.GetDadosGerais()
			};
			return View(dashboardData.dadosGerais);
		}

		public async Task<IActionResult> GetDashBoardData(int? month = null, int? final_month = null, int? year = null)
		{
			var dashboardData = new DashboardDataViewModel
			{
				totalAVencer = await _dadosFaturamentoService.GetTotalAVencer(month, final_month, year),
				total = await _dadosFaturamentoService.GetTotal(month, final_month, year),
				dadosGerais = await _dadosFaturamentoService.GetDadosGerais(month, final_month, year)
			};

			return Json(dashboardData);
		}
	}
}
